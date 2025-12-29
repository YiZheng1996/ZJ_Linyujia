using MainUI.MQTT;
using MainUI.Procedure.Controls;
using Sunny.UI;
using Color = System.Drawing.Color;

namespace MainUI
{
    public partial class UcHMI : UserControl
    {
        MQTT.MqttClient mqttClient;
        frmMainMenu frm = new();
        public delegate void RunStatusHandler(bool obj);
        public event RunStatusHandler EmergencyStatusChanged;
        ParaConfig paraconfig;
        TestParaConfig testPara;
        Dictionary<int, AntdUI.Button> pairs = [];
        Dictionary<int, UIDigitalLabel> dicAI = [];
        Dictionary<int, UcRainyManual> DicRainy = [];
        Dictionary<int, UISwitch> DicDO = [];
        Dictionary<int, UIDigitalLabel> DicAO = [];
        Dictionary<int, Procedure.Controls.SwitchPictureBox> dicDI = [];
        public delegate void TestStateHandler(bool isTesting);
        public event TestStateHandler TestStateChanged;

        public UcHMI()
        {
            if (!DesignMode)
            {
                InitializeComponent();

                this.HandleCreated += (s, e) =>
                {
                    // 现在句柄已创建，可以安全地启动Timer
                    timer1.Interval = 1000;
                    timer1.Tick += Timer1_Tick;
                    timer1.Start();
                };

            }
        }
        private void SafeInvoke(Action action)
        {
            // 检查控件是否已创建句柄且未被释放
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                // 如果句柄还未创建，延迟执行
                this.HandleCreated += (s, e) => action();
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        #region 初始化
        public void Init()
        {
            try
            {
                OPCHelper.Init();
                AddBtn();
                AddRainy();
                LoaddicDI();
                LoaddicDO();
                LoaddicAO();
                LoaddicAI();
                OPCHelper.PUBgrp.PUBGroupChanged += PUBgrp_PUBGroupChanged;
                OPCHelper.PUBgrp.Fresh();
                OPCHelper.AIgrp.AIvalueGrpChanged += AIgrp_AIvalueGrpChanged;
                OPCHelper.AIgrp.Fresh();
                OPCHelper.DIgrp.DIGroupChanged += DIgrp_DIGroupChanged;
                OPCHelper.DIgrp.Fresh();
                OPCHelper.Wsdgrp.WSDvalueGrpChaned += WSDgrp_WSDvalueGrpChaned;
                OPCHelper.Wsdgrp.Fresh();
                OPCHelper.AOgrp.AOvalueGrpChaned += AOgrp_AOvalueGrpChanged;
                OPCHelper.AOgrp.Fresh();
                OPCHelper.DOgrp.DOgrpChanged += DOgrp_DOgrpChanged; ;
                OPCHelper.DOgrp.Fresh();
                BaseTest.TestStateChanged += BaseTest_TestStateChanged;
                BaseTest.TipsChanged += BaseTest_TipsChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 初始化MQTT连接
        public async void MQTTInit()
        {
            MqttConfig _config = new();
            _config.Load();
            mqttClient = new(_config);
            await mqttClient.ConnectAsync();
        }

        private void BaseTest_TipsChanged(object sender, object info)
        {
            AppendText(info.ToString());
        }

        private void BaseTest_TestStateChanged(bool isTesting)
        {
            Disable(isTesting);
            if (!isTesting)
            {
                IsTestEnd();
            }
        }

        private void Disable(bool isTesting)
        {
            LabAO00Out.Enabled = !isTesting;
            LabAO01Out.Enabled = !isTesting;
            PanelCurrent.Enabled = !isTesting;
            PanelTimeSetting.Enabled = !isTesting;
            btnProductSelection.Enabled = !isTesting;
        }

        /// <summary>
        /// 加载DI模块
        /// </summary>
        private void LoaddicDI()
        {
            dicDI.Clear();
            foreach (var item in grpDI.Controls)
            {
                if (item is Procedure.Controls.SwitchPictureBox)
                {
                    var box = item as Procedure.Controls.SwitchPictureBox;
                    dicDI.Add(box.Index, box);
                }
            }

            dicDI.Add(switchRun.Index, switchRun);
            dicDI.Add(switchBuShui.Index, switchBuShui);
        }

        //加载AI模块
        private void LoaddicAI()
        {
            dicAI.Clear();
            AddContrls(grpAI);
        }

        //加载AI模块
        private void LoaddicDO()
        {
            DicDO.Clear();
            AddContrls(grpDO);
        }

        private void AddBtn()
        {
            pairs.Clear();
            pairs.Add(0, btnTechnology);
            pairs.Add(1, btnCurve);
        }

        private void LoaddicAO()
        {
            UIDigitalLabel[] labLabAO =
            [
                LabAO00, LabAO01, LabAO02, LabAO03, LabAO04, LabAO05, LabAO06, LabAO07
            ];
            foreach (var lab in labLabAO)
            {
                DicAO.TryAdd(lab.Tag.ToInt32(), lab);
            }
        }

        private void AddRainy()
        {
            DicRainy.Clear();
            AddContrls(grpRainy);
        }

        /// <summary>
        /// 递归查找
        /// </summary>
        /// <param name="con"></param>
        private void AddContrls(Control con)
        {
            foreach (Control item in con.Controls)
            {
                if (item is UcRainyManual)
                {
                    int key = item.Tag.ToInt32();
                    if (!DicRainy.ContainsKey(key))
                        DicRainy.Add(key, item as UcRainyManual);
                }
                if (item is UIDigitalLabel)
                {
                    var sp = item as UIDigitalLabel;
                    var Index = sp.Tag.ToInt32();
                    dicAI.TryAdd(Index, sp);
                }
                if (item is UISwitch)
                {
                    int key = item.Tag.ToInt32();
                    if (!DicDO.ContainsKey(key))
                        DicDO.Add(key, item as UISwitch);
                }
                AddContrls(item);
            }
        }
        #endregion

        #region 值改变事件
        private void AIgrp_AIvalueGrpChanged(object sender, int index, double value)
        {
            if (DicRainy.TryGetValue(index, out UcRainyManual ucRainy))
            {
                ucRainy.Pressure = value;
            }
            if (index > 7 && index < 15)
            {
                DicRainy[index - 8].InternetTraffic = value;
            }
            if (dicAI.TryGetValue(index, out UIDigitalLabel uIDigital))
            {
                uIDigital.Value = value;
            }
        }
        private void AOgrp_AOvalueGrpChanged(object sender, int index, double value)
        {
            if (DicAO.TryGetValue(index, out UIDigitalLabel label))
            {
                if (index == 4)
                {
                    label.Value = value / 10;
                }
                else
                {
                    label.Value = value;
                }

            }
        }
        double avg;
        double liuliang1_avg, liuliang2_avg, liuliang3_avg, liuliang4_avg, liuliang5_avg, liuliang6_avg, liuliang7_avg;
        private DateTime startTime;
        private void DIgrp_DIGroupChanged(object sender, int index, bool value)
        {
            try
            {
                int key = index / 2;
                if (DicRainy.TryGetValue(key, out UcRainyManual ucRainy))
                {
                    if (index % 2 == 0)
                    {
                        DicRainy[key].IsOpen = CheckStatus(OPCHelper.DIgrp.DiList, key);
                    }
                }

                if (dicDI.TryGetValue(index, out Procedure.Controls.SwitchPictureBox swLabel))
                {
                    swLabel.Switch = value;
                    switch (index)
                    {
                        case 15:
                            if (value) EndTest("变频器1故障,试验停止");
                            break;
                        case 17:
                            if (value) EndTest("变频器2故障,试验停止");
                            break;
                        default:
                            break;
                    }
                }
                if (index == 22 && value) //启动信号  true 开始电能、流量采值
                {
                    Lab_DianNengCount.Value = 0;
                    Lab_LiuLiangCount.Value = 0;

                    DianNengCount.Clear();//电能清空

                    LiuLiangCount1.Clear();//流量清空
                    LiuLiangCount2.Clear();
                    LiuLiangCount3.Clear();
                    LiuLiangCount4.Clear();
                    LiuLiangCount5.Clear();
                    LiuLiangCount6.Clear();
                    LiuLiangCount7.Clear();

                    SafeInvoke(() =>
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    });
                    startTime = DateTime.Now;
                }
                else if (index == 22 && value == false) //判定 本地启动 DI信号 关闭状态 计算 电能统计
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    TimeSpan elapsed = DateTime.Now - startTime;
                    double totalSeconds = elapsed.TotalSeconds;
                    if (DianNengCount.Count > 0)
                    {
                        avg = DianNengCount.Average();//能耗平均数

                        //1分钟总耗电能 = 1.02 kW × (1/60) h = 0.017 kWh（度）
                        double Zong = avg * (totalSeconds / 3600);
                        Lab_DianNengCount.Value = Zong;
                    }
                    if (LiuLiangCount7.Count > 0)//即使对应管路没开阀，也可记录0值
                    {
                        liuliang1_avg = LiuLiangCount1.Average();//管路1流量平均数
                        liuliang2_avg = LiuLiangCount2.Average();
                        liuliang3_avg = LiuLiangCount3.Average();
                        liuliang4_avg = LiuLiangCount4.Average();
                        liuliang5_avg = LiuLiangCount5.Average();
                        liuliang6_avg = LiuLiangCount6.Average();
                        liuliang7_avg = LiuLiangCount7.Average();

                        double ZongLiuliang = liuliang1_avg + liuliang2_avg + liuliang3_avg + liuliang4_avg + liuliang5_avg + liuliang6_avg + liuliang7_avg;
                        Lab_LiuLiangCount.Value = ZongLiuliang / totalSeconds; // 总流量除以总秒数 得到m³/s
                    }

                }
                else if (index == 20)//如果信号是false为本地控制，禁用工艺界面；是true为远程控制，启动当前工艺界面
                {
                    this.grpRainy.Enabled = value;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DI模块事件报错：" + ex.Message);
            }
        }
        private void DOgrp_DOgrpChanged(object sender, int index, bool value)
        {
            if (DicDO.TryGetValue(index, out UISwitch iSwitch))
            {
                iSwitch.Active = value;
            }
        }

        private void EndTest(string txt)
        {
            IsTestEnd();
            AppendText(txt);
            NlogHelper.Default.Debug(txt);
        }
        private void WSDgrp_WSDvalueGrpChaned(object sender, int index, double value)
        {
            switch (index)
            {
                case 0:
                    //LabTemperature.Value = value;
                    break;
                case 1:
                    //LabHumidity.Value = value;
                    break;
                default:
                    break;
            }
        }
        private void PUBgrp_PUBGroupChanged(object sender, int index, object value)
        {
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 参数
        /// <summary>
        /// 读取配置文件，配置参数
        /// </summary>
        private void InitParaConfig()
        {
            try
            {
                if (VarHelper.mTestViewModel == null) return;
                paraconfig = new();
                paraconfig.SetSectionName(VarHelper.mTestViewModel.ModelName);
                paraconfig.Load();
                Manualparameters(paraconfig);
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"加载参数错误：{ex.Message}");
            }
        }

        //刷新型号
        public void sRefresh()
        {
            try
            {
                if (string.IsNullOrEmpty(VarHelper.mTestViewModel.TypeName)) return;
                InitParaConfig();
            }
            catch (Exception ex)
            {
                MessageHelper.MessageYes("刷新型号错误：" + ex.Message);
            }
        }

        // 根据型号输出点位信息
        private void Manualparameters(ParaConfig paraconfig) { }
        #endregion

        #region 自动试验
        private CancellationTokenSource _cancellationTokenSource = new();
        private async Task BackgroundWorker(CancellationToken token)
        {
            try
            {
                AppendText("试验开始");
                ////while (!token.IsCancellationRequested)
                ////{
                ////    Debug.WriteLine($"自动试验正在运行中！");
                ////    await Task.Delay(1000, token);
                ////    //Delay(600, 100, token, () => OPCHelper.AIgrp[0].ToString() == "21");
                ////}


            }
            catch (Exception ex)
            {
                string errorMsg = $"自动试验时发生异常：{ex.Message}";
                NlogHelper.Default.Error(errorMsg);
                MessageHelper.MessageOK(errorMsg);
            }
        }

        /// <summary>
        /// 电能耗
        /// </summary>
        /// <param name="energyResult"></param>
        private async void UploadElectricityMQTT(EnergyResult energyResult)
        {
            EnergyResult energy = new()
            {
                usingenergy_equip_code = "999-699",   //默认值
                equip_name = "动车组淋雨架",      //默认值
                collect_type = 1,                //默认值
                meteringdevice_code = "SL1,SL2,SL3,SL4,SL5,SL6,SL7",        //默认值
                metering_unit = "kWh",         //默认值
                collection_source = 4,           //默认值
                collection_type = 2,             //默认值
                energy_type = "3300",       //默认值 电能、水能
                data_usage = "31",               //默认值
                collect_part = "整机电量",        //默认值
                locomotive_type = VarHelper.mTestViewModel.ModelName,
                singer_car_code = txtNumber.Text.Trim(),
                collection_start_time = energyResult.collection_start_time,
                collection_end_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                energy_value = Lab_DianNengCount.Value,
                //votage_level = Lab_LiuLiangCount.Value  //水能耗？
            };
            await SendEnergyConsumptionAsync(energy);
        }

        /// <summary>
        /// 水能耗
        /// </summary>
        /// <param name="energyResult"></param>
        private async void UploadWaterMQTT(EnergyResult energyResult)
        {
            EnergyResult energy = new()
            {
                usingenergy_equip_code = "999-699",   //默认值
                equip_name = "动车组淋雨架",      //默认值
                collect_type = 1,                //默认值
                meteringdevice_code = "D1",        //默认值
                metering_unit = "t",         //默认值
                collection_source = 4,           //默认值
                collection_type = 2,             //默认值
                energy_type = "0207",            // 水能
                data_usage = "31",               //默认值
                collect_part = "整机水量",        //默认值
                locomotive_type = VarHelper.mTestViewModel.ModelName,
                singer_car_code = txtNumber.Text.Trim(),
                collection_start_time = energyResult.collection_start_time,
                collection_end_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                energy_value = Lab_LiuLiangCount.Value / 3600  // 换算总流量 m³/s
            };
            await SendEnergyConsumptionAsync(energy);
        }

        //// 试验倒计时 - 带时分秒版本
        //private void StartCountdown(int totalMinutes, CancellationToken token)
        //{
        //    TimeSpan remainingTime = TimeSpan.FromMinutes(totalMinutes);
        //    Task.Run(async () =>
        //    {
        //        while (!token.IsCancellationRequested)
        //        {
        //            label8.Text = $"{remainingTime.Hours:D2}:{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
        //            await Task.Delay(1000, token);
        //            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
        //        }
        //    }, _cancellationTokenSource.Token);
        //}

        // 试验倒计时 - 整数秒显示
        private void StartCountdown(int totalSeconds, CancellationToken token)
        {
            int remainingSeconds = totalSeconds;
            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested && remainingSeconds >= 0)
                {
                    // 使用Invoke在UI线程更新Label
                    LabTestTime.Invoke(new Action(() =>
                    {
                        LabTestTime.Value = remainingSeconds.ToDouble();
                    }));

                    if (remainingSeconds == 0)
                        break;

                    await Task.Delay(1000, token);
                    remainingSeconds--;
                }
                // 计时到达后关闭喷淋
                OPCHelper.DOgrp[18] = false; //远程启动
                OPCHelper.DOgrp[19] = true; //远程停止
                AppendText("远程启动关闭");
                Thread.Sleep(1000);
                OPCHelper.DOgrp[19] = false;

            }, token);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                //(bool Result, string txt) = FrmText();
                //if (!Result)
                //{
                //    MessageHelper.MessageOK(txt, AntdUI.TType.Error);
                //    return;
                //}
                //Disable(true);
                //InitLineSeries();
                //InitializeChart();
                //_updateTimer.Start();
                //TestStateChanged?.Invoke(true);
                //_cancellationTokenSource = new CancellationTokenSource();
                //StartCountdown(LoadTestPara().SprayTimeSet.ToInt(), _cancellationTokenSource.Token);
                //await Task.Run(() => BackgroundWorker(_cancellationTokenSource.Token),
                // _cancellationTokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine($"试验已取消：{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"试验开始错误：{ex.Message}");
            }
        }

        private void btnStopTest_Click(object sender, EventArgs e) => IsTestEnd();

        private (bool Result, string txt) FrmText()
        {
            if (string.IsNullOrEmpty(VarHelper.mTestViewModel.ModelName))
            {
                return (false, "未选择型号，无法启动!");
            }

            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                return (false, "车号未填写，无法启动!");
            }

            if (string.IsNullOrEmpty(UIDigitalLabelExtensions.GetTestParams().SprayTimeSet))
            {
                return (false, "试验时间未设置，无法启动!");
            }
            return (true, "");
        }

        // 结束试验操作
        private void IsTestEnd()
        {
            try
            {
                //Disable(false);
                //_updateTimer?.Stop();
                //AppendText("试验结束");
                //TestStateChanged?.Invoke(false);
                _cancellationTokenSource.Cancel();
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"结束试验错误：{ex.Message}", ex);
                MessageHelper.MessageOK(frm, $"结束试验错误：{ex.Message}");
            }
        }
        #endregion

        #region 曲线控件
        // 曲线名称列表
        private string[] _parameterNames;
        // 定时器用于更新数据
        private System.Timers.Timer _updateTimer;
        // 用于存储所有系列数据
        private ObservableCollection<ISeries> _allSeries;
        // 用于图表实际显示的系列数据
        private ObservableCollection<ISeries> _visibleSeries;

        // 初始化计时器
        private void InitializeTimer()
        {
            _updateTimer = new System.Timers.Timer(1000);
            _updateTimer.Elapsed += (s, e) =>
            {
                // 更新UI时需要调用UI线程
                BeginInvoke(new Action(() =>
                {
                    UpdateTimer_Tick(s, e);
                }));
            };
            _updateTimer.AutoReset = true;
        }

        // 初始化曲线名称
        private void InitializeParameterNames()
        {
            _parameterNames =
            [
                "喷淋压力(Kpa)",
                "喷淋流量(m³/h)",
            ];
        }

        // 初始化折线
        private void InitLineSeries()
        {
            _allSeries = [];
            _visibleSeries = [];
            for (int i = 0; i < _parameterNames.Length; i++)
            {
                string paramName = _parameterNames[i].ToLower();
                var points = new ObservableCollection<DateTimePoint>
                {
                    new(DateTime.Now, 0)
                };
                LineSeries<DateTimePoint> lineSeries = new()
                {
                    Fill = null,
                    Values = points, //绑定值
                    LineSmoothness = 0.1f,// 设置线条平滑度
                    Name = _parameterNames[i],
                    Stroke = new SolidColorPaint(GetParameterSKColor(i), 1.5f),//线条宽度
                    GeometrySize = 2,//外点大小
                    GeometryFill = new SolidColorPaint(GetParameterSKColor(i), 2),//内点颜色
                    GeometryStroke = new SolidColorPaint(GetParameterSKColor(i), 2), //内点大小
                    ScalesYAt = paramName.Contains("流量") ? 1 : 0
                };
                _allSeries.Add(lineSeries);
                _visibleSeries.Add(lineSeries);
            }
        }

        // 初始化视图还原按钮
        private void InitViewRecovery()
        {
            try
            {
                Label zoomInstructionLabel = new()
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(235, 227, 221),
                    Text = "提示：鼠标滚轮可放大缩小，按住鼠标左键拖动可平移图表，按住鼠标右键平移可以局部放大",
                };
                Color color = Color.FromArgb(90, 124, 236);
                UIButton zoomButton = new()
                {
                    Text = "还原视图",
                    Dock = DockStyle.Right,
                    Size = new Size(120, 30),
                    //Location = new Point(750, 0),
                    ForeColor = Color.FromArgb(235, 227, 221),
                    Font = new Font("思源黑体 CN Bold", 13),
                    BackColor = Color.FromArgb(70, 75, 85),
                    FillColor = color,
                    FillColor2 = color,
                    RectColor = color,
                    RectDisableColor = color,
                };
                zoomButton.Click += (s, e) =>
                {
                    // 还原视图
                    if (cartesianChart1.XAxes != null && cartesianChart1.XAxes.Any())
                    {
                        foreach (var axis in cartesianChart1.XAxes)
                        {
                            axis.MinLimit = null;
                            axis.MaxLimit = null;
                        }
                    }

                    if (cartesianChart1.YAxes != null && cartesianChart1.YAxes.Any())
                    {
                        foreach (var axis in cartesianChart1.YAxes)
                        {
                            axis.MinLimit = null;
                            axis.MaxLimit = null;
                        }
                    }
                    cartesianChart1.Invalidate();
                };
                Panel panel = new()
                {
                    Dock = DockStyle.Bottom,
                    Height = 30,
                    BackColor = Color.FromArgb(49, 54, 64),
                };
                panel.Controls.Add(zoomButton);
                panel.Controls.Add(zoomInstructionLabel);
                cartesianChart1.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"加载还原视图按钮错误：{ex.Message}");
            }
        }

        // 初始化图表
        private void InitializeChart()
        {
            LiveCharts.Configure(config =>
            config
                .HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('汉'))
             //.UseRightToLeftSettings() // 启用从右到左的工具提示      
             );

            // 缩放模式
            cartesianChart1.ZoomMode = ZoomAndPanMode.Both;
            if (cartesianChart1.XAxes != null && cartesianChart1.XAxes.Any())
            {
                foreach (var axis in cartesianChart1.XAxes)
                {
                    axis.MinLimit = null; // 启用X轴缩放
                    axis.MaxLimit = null;
                    axis.MinZoomDelta = 0.1;  // 控制最小缩放增量
                }
            }
            if (cartesianChart1.YAxes != null && cartesianChart1.YAxes.Any())
            {
                foreach (var axis in cartesianChart1.YAxes)
                {
                    axis.MinLimit = null; // 启用Y轴缩放
                    axis.MaxLimit = null;
                    axis.MinZoomDelta = 0.1;  // 控制最小缩放增量
                }
            }

            // 设置图表
            cartesianChart1.Series = _visibleSeries;
            cartesianChart1.MouseWheel += (sender, e) =>
            {
                // 如果按住Ctrl键，则仅缩放X轴
                if (ModifierKeys == Keys.Control)
                {
                    // 手动计算X轴缩放
                    var deltaZoom = e.Delta > 0 ? 0.2 : -0.2;
                    foreach (var axis in cartesianChart1.XAxes)
                    {
                        if (axis.MinLimit != null && axis.MaxLimit != null)
                        {
                            var range = axis.MaxLimit.Value - axis.MinLimit.Value;
                            var center = (axis.MaxLimit.Value + axis.MinLimit.Value) / 2;
                            var newRange = range * (1 - deltaZoom);
                            axis.MinLimit = center - newRange / 2;
                            axis.MaxLimit = center + newRange / 2;
                        }
                    }
                    cartesianChart1.Invalidate();
                }
            };
            // 设置图表标题和轴标签
            cartesianChart1.Title = new LabelVisual
            {
                Text = "淋雨试验实时曲线",
                TextSize = 22,
                Paint = new SolidColorPaint(SKColors.White)
            };

            // 设置Y轴
            cartesianChart1.YAxes =
            [
                new Axis
                {
                    MinLimit = 0, // 设置Y轴最小值
                    MaxLimit = 1000, // 设置Y轴最大值
                    Name = "喷淋压力(Kpa)",
                    LabelsDensity = 0.85f, //轴密度，默认值为 0.85，小于 0 的值将使标签重叠。
                    InLineNamePlacement = false, // 名称顶部(会导致顶部图例存在位置与顶部曲线重叠)
                    NamePaint = new SolidColorPaint(SKColors.White),
                    LabelsPaint = new SolidColorPaint(SKColors.White)
                },
                new Axis
                {

                    MinLimit = 0, // 设置Y轴最小值
                    MaxLimit = 100, // 设置Y轴最大值
                    Name = "喷淋流量(m³/h)",
                    LabelsDensity = 0.85f, //轴密度，默认值为 0.85，小于 0 的值将使标签重叠。
                    Position = AxisPosition.End,
                    InLineNamePlacement = false, // 名称顶部(会导致顶部图例存在位置与顶部曲线重叠)
                    NamePaint = new SolidColorPaint(SKColors.White),
                    LabelsPaint = new SolidColorPaint(SKColors.White)
                }
            ];
            // 设置X轴
            cartesianChart1.XAxes =
            [
                new Axis
                {
                     Labeler = value =>
                     {
                         // 检查值是否在有效的DateTime范围内
                         if (value >= DateTime.MinValue.Ticks && value <= DateTime.MaxValue.Ticks)
                         {
                             return new DateTime((long)value).ToString("HH:mm:ss");
                         }
                         else
                         {
                             return "--:--:--"; // 显示无效时间的占位符
                         }
                     },
                    Name = "时间(S)",
                    LabelsRotation = 0, // 标签旋转角度
                    //设置X轴的最小值为当前时间减去60秒的Ticks，最大值为当前时间加上60秒的Ticks
                    //MinLimit = DateTime.Now.AddSeconds(-10).Ticks,
                    //MaxLimit = DateTime.Now.AddSeconds(20).Ticks,
                    MinStep = TimeSpan.FromSeconds(1).Ticks, // 使用采样周期作为最小步长
                    UnitWidth = TimeSpan.FromSeconds(1).Ticks, // 使用采样周期作为单位宽度
                    NamePaint = new SolidColorPaint(SKColors.White),
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    TextSize = 16, // 设置文本大小
                    LabelsAlignment = Align.End, // 设置标签的对齐方式
                    Position = AxisPosition.Start,  // 设置轴的位置（底部）
                    ShowSeparatorLines = true, // 显示分隔线
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray)
                    {
                        StrokeThickness = 1, // 分隔线的粗细
                        PathEffect = new DashEffect([3, 3]) // 分隔线的虚线效果
                    },
                }
            ];

            cartesianChart1.TooltipTextPaint = new SolidColorPaint(SKColors.Black);
            cartesianChart1.LegendTextPaint = new SolidColorPaint(SKColors.White);// 设置图例
            cartesianChart1.LegendPosition = LegendPosition.Top;
            cartesianChart1.LegendTextSize = 16;
        }

        // 初始化折线颜色
        private SKColor GetParameterSKColor(int index)
        {
            // 使用HSV颜色空间生成均匀分布的鲜艳颜色
            // 黄金角度约为137.5°，用于在色轮上均匀分布颜色
            double goldenAngleRatio = 0.618033988749895;

            // 使用索引乘以黄金角度比例，确保颜色均匀分布
            double hue = (index * goldenAngleRatio * 360) % 360;

            // 降低亮度，增加饱和度，使颜色更深更鲜艳
            double saturation = 1.0;  // 100%饱和度
            double brightness = 0.6;  // 60%亮度 - 比之前的95%亮度更深

            // 使用参数索引来稍微变化亮度，确保不同的深色
            if (index % 3 == 0)
            {
                brightness = 0.65;  // 65%亮度
            }
            else if (index % 3 == 1)
            {
                brightness = 0.75;  // 55%亮度
            }
            else
            {
                brightness = 0.60;  // 60%亮度
            }

            // 使用HSL转换为SKColor
            return SKColor.FromHsl(
                (float)hue,
                (float)(saturation * 100),
                (float)(brightness * 100)
            );
        }

        // 数据刷新
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            // 更新所有系列的数据，不管是否可见
            for (int i = 0; i < _allSeries.Count; i++)
            {
                var lineSeries = (LineSeries<DateTimePoint>)_allSeries[i];
                var values = (ObservableCollection<DateTimePoint>)lineSeries.Values;
                // 获取对应参数的实际数据值
                double newValue = GetRealParameterValue(i);
                // 添加新数据点
                values.Add(new DateTimePoint(currentTime, newValue));
                //折线平移
                if (values.Count > 60)
                {
                    values.RemoveAt(0);
                }
            }
        }

        // 获取实际值
        private double GetRealParameterValue(int parameterIndex)
        {
            string paramName = _parameterNames[parameterIndex].ToLower();
            try
            {
                // 首先检查AIGrp中是否有对应的数据
                if (OPCHelper.AIgrp != null)
                {
                    //TODO:暂时注释，正式调试时调用
                    //if (paramName.Contains("压力"))
                    //    return OPCHelper.AIgrp[0];
                    //else if (paramName.Contains("流量"))
                    //    return OPCHelper.AIgrp[1];
                }
                return GetParameterValue(parameterIndex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"获取参数 {paramName} 的值时出错: {ex.Message}");
                // 发生异常时返回随机数据作为备用
                return GetParameterValue(parameterIndex);
            }
        }

        private double GetParameterValue(int parameterIndex)
        {
            // 这里替换为你的实际数据获取逻辑
            Random random = new();
            // 根据参数类型生成不同范围的随机值
            string paramName = _parameterNames[parameterIndex].ToLower();

            if (paramName.Contains("压力"))
            {
                return Math.Round(random.Next(20, 1000) + random.NextDouble(), 1);
            }
            else if (paramName.Contains("流量"))
            {
                return Math.Round(random.Next(10, 100) + random.NextDouble(), 1);
            }

            // 其他参数
            return Math.Round(random.Next(0, 1000) + random.NextDouble(), 1);
        }
        #endregion

        #region 模拟量设置
        private void LabAO00Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog00(LabAO00, sender, frm);

        private void LabAO01Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog01(LabAO01, sender, frm);

        private void LabAO02Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog02(LabAO02, sender, frm);

        private void LabAO03Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog03(LabAO03, sender, frm);

        private void LabAO04Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog04(LabAO04, sender, frm);

        private void LabAO05Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog05(LabAO05, sender, frm);

        private void LabAO06Out_Click(object sender, EventArgs e) =>
            UIDigitalLabelExtensions.ShowSettingDialog06(LabAO06, sender, frm);

        private void LabAO07Out_Click(object sender, EventArgs e) =>
          UIDigitalLabelExtensions.ShowSettingDialog07(LabAO07, sender, frm);
        #endregion

        private void InitRainy()
        {
            for (int i = 0; i < DicRainy.Count; i++)
            {
                Invoke(() =>
                {
                    int key = i + 1;
                    // DicRainy[i].TitleName = $"通道{key}";
                    DicRainy[i].PressureName = $"压力传感器{key}(MPa)";
                    DicRainy[i].InternetTrafficName = $"流量传感器{key}(m³/h)";
                    // DicRainy[i].SolenoidName = $"电磁阀控制{key}";
                    DicRainy[i].OpenClick += UcHMI_OpenClick;
                });
            }

            InternetTrafficBZConfig bZConfig = new();
            bZConfig.Load();

            DicRainy[0].TitleName = "供车顶";
            DicRainy[0].InternetTrafficBZ = $"流量标准{bZConfig.Standard01}(m³/h)";

            DicRainy[1].TitleName = "西侧墙";
            DicRainy[1].InternetTrafficBZ = $"流量标准{bZConfig.Standard02}(m³/h)";

            DicRainy[2].TitleName = "西车底";
            DicRainy[2].InternetTrafficBZ = $"流量标准{bZConfig.Standard03}(m³/h)";

            DicRainy[3].TitleName = "北车罩";
            DicRainy[3].InternetTrafficBZ = $"流量标准{bZConfig.Standard04}(m³/h)";

            DicRainy[4].TitleName = "南车罩";
            DicRainy[4].InternetTrafficBZ = $"流量标准{bZConfig.Standard05}(m³/h)";

            DicRainy[5].TitleName = "东侧墙";
            DicRainy[5].InternetTrafficBZ = $"流量标准{bZConfig.Standard06}(m³/h)";

            DicRainy[6].TitleName = "东车底";
            DicRainy[6].InternetTrafficBZ = $"流量标准{bZConfig.Standard07}(m³/h)";
        }

        private void UcHMI_OpenClick(object sender, EventArgs e)
        {
            if (sender is not UcRainyManual manual)
                return;

            int key = manual.Tag.ToInt32();
            if (DicRainy.TryGetValue(key, value: out UcRainyManual ucRainy))
            {
                if (CheckStatus(OPCHelper.DOgrp.DOlist, key))
                {
                    SetStatus(OPCHelper.DOgrp.DOlist, key, false);
                }
                else
                {
                    SetStatus(OPCHelper.DOgrp.DOlist, key, true);
                }

                //int index = key * 2;
                //bool isOpen = ucRainy.IsOpen;
                //OPCHelper.DOgrp[index] = !isOpen;
                //OPCHelper.DOgrp[index + 1] = isOpen;
            }
        }

        /// <summary>
        /// 检测指定状态索引的状态值
        /// 状态索引0对应数组下标[0,1]，状态索引1对应数组下标[2,3]，以此类推
        /// </summary>
        /// <param name="dataArray">数据数组</param>
        /// <param name="statusIndex">状态索引（0,1,2...）</param>
        /// <returns>true: [true,false], false: [false,true], null: 其他组合或索引无效</returns>
        public static bool CheckStatus(bool[] dataArray, int statusIndex)
        {
            // 计算对应的数组下标
            int index1 = statusIndex * 2;
            int index2 = statusIndex * 2 + 1;

            // 检查下标有效性
            if (index1 < 0 || index2 >= dataArray.Length)
                return false;

            bool value1 = dataArray[index1];
            bool value2 = dataArray[index2];

            // 状态判断：[true,false] = true, [false,true] = false
            if (value1 == true && value2 == false)
                return true;
            else if (value1 == false && value2 == true)
                return false;
            else
                return false;
        }

        /// <summary>
        /// 设置指定状态索引的状态值
        /// </summary>
        /// <param name="dataArray">数据数组</param>
        /// <param name="statusIndex">状态索引</param>
        /// <param name="status">要设置的状态值</param>
        /// <returns>设置是否成功</returns>
        public static bool SetStatus(bool[] dataArray, int statusIndex, bool status)
        {
            // 计算对应的数组下标
            int index1 = statusIndex * 2;
            int index2 = statusIndex * 2 + 1;

            // 检查下标有效性
            if (index1 < 0 || index2 >= dataArray.Length)
                return false;

            if (status) // true = [true,false]
            {
                OPCHelper.DOgrp[index1] = true;
                OPCHelper.DOgrp[index2] = false;
            }
            else // false = [false,true]
            {
                OPCHelper.DOgrp[index1] = false;
                OPCHelper.DOgrp[index2] = true;
            }

            return true;
        }

        private void UcHMI_Load(object sender, EventArgs e)
        {
            MQTTInit();
            InitRainy();
            LoadTestPara();
            InitializeTimer();
            InitViewRecovery();
            InitializeParameterNames();
            InitializeChart();
            InitializePlcDefaultValue();
        }

        private TestParaConfig LoadTestPara()
        {
            if (testPara == null)
            {
                testPara = new TestParaConfig();
                testPara.Load();
            }
            return testPara;
        }

        private void InitializePlcDefaultValue()
        {
            // 初始化PLC默认值
            OPCHelper.AOgrp.CA00 = (double)(LoadTestPara()?.WaterHighSet.ToDouble());
            OPCHelper.AOgrp.CA01 = (double)(LoadTestPara()?.WaterLowSet.ToDouble());
            OPCHelper.AOgrp.CA02 = (double)(LoadTestPara()?.WaterVeryLowSet.ToDouble());
            OPCHelper.AOgrp.CA03 = (double)(LoadTestPara()?.InternetTrafficSet.ToDouble());
            OPCHelper.AOgrp.CA04 = (int)(LoadTestPara()?.SprayTimeSet.ToDouble());
            OPCHelper.AOgrp.CA05 = (double)(LoadTestPara()?.Frequency1Set.ToDouble());
            OPCHelper.AOgrp.CA06 = (double)(LoadTestPara()?.Frequency2Set.ToDouble());
            OPCHelper.AOgrp.CA07 = (double)(LoadTestPara()?.AirSet.ToDouble());
        }

        private void AppendText(string text)
        {
            txtTestRecord.AppendText($"{DateTime.Now:HH:mm:ss}：{text}\n");
            txtTestRecord.ScrollToCaret();
        }

        private void BtnColor(int index)
        {
            foreach (var item in pairs)
            {
                if (item.Key == index)
                {
                    item.Value.ForeColor = Color.FromArgb(235, 227, 221);
                }
                else
                {
                    item.Value.ForeColor = Color.FromArgb(128, 128, 128);
                }
            }
        }

        private void btnTechnology_Click(object sender, EventArgs e)
        {
            tabs1.SelectedIndex = 0;
            BtnColor(tabs1.SelectedIndex);
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            tabs1.SelectedIndex = 1;
            BtnColor(tabs1.SelectedIndex);
        }

        private void btnProductSelection_Click(object sender, EventArgs e)
        {
            using frmSpec frmSpec = new();
            VarHelper.ShowDialogWithOverlay(frm, frmSpec);
            if (frmSpec.DialogResult == DialogResult.OK)
            {
                txtModel.Text = VarHelper.mTestViewModel.ModelName;
                sRefresh();
            }
        }

        // 开始时间
        private string _testStartTime = string.Empty;
        private void uiSwitch1_ValueChanged(object sender, bool value)
        {
            var sder = sender as UISwitch;
            int Index = sder.Tag.ToInt32();
            if (Index == 18)
            {
                OPCHelper.DOgrp[sder.Tag.ToInt32()] = value; //远程启动
                OPCHelper.DOgrp[19] = !value; //远程停止
                if (!value)
                {
                    AppendText("远程启动关闭");
                    Thread.Sleep(1000);
                    OPCHelper.DOgrp[19] = false;
                    IsTestEnd();
                    if (MessageBox.Show(this, "检测到关闭远程启动，是否上传数据到中控系统？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // 电能耗
                        UploadElectricityMQTT(new EnergyResult()
                        {
                            collection_start_time = _testStartTime
                        });

                        // 水能耗
                        UploadWaterMQTT(new EnergyResult()
                        {
                            collection_start_time = _testStartTime
                        });
                    }
                    _testStartTime = string.Empty; // 上传后清空，避免下次误用
                }
                else
                {
                    AppendText("远程启动开启");
                    _testStartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    _cancellationTokenSource = new CancellationTokenSource();
                    StartCountdown(UIDigitalLabelExtensions.GetTestParams().SprayTimeSet.ToInt(), _cancellationTokenSource.Token);
                }
            }
            else
            {
                OPCHelper.DOgrp[Index] = value;
            }
        }

        #region MQTT数据回传
        // 发送能源数据
        public async Task SendEnergyConsumptionAsync(EnergyResult energy)
        {
            try
            {
                MqttOperate mqttOperate = new(mqttClient);
                //EnergyDataResponse energyData = new();
                //energyData.Results.Add(energy);
                var (success, message) = await mqttOperate
                        .SendEnergyConsumptionAsync(energy);
                AppendText($"发送能耗数据：{message}");
            }
            catch (Exception ex)
            {
                string errorMsg = $"发送能耗数据时发生异常：{ex.Message}";
                NlogHelper.Default.Error(errorMsg);
                MessageHelper.MessageOK(errorMsg);
            }
        }

        // 发送故障信息数据
        public async Task SendFaultInformationAsync(FaultResult fault, bool Start = false)
        {
            try
            {
                MqttOperate mqttOperate = new(mqttClient);
                var FaultData = new FaultDataResponse
                {
                    Start = Start
                };
                FaultData.Results.Add(fault);
                var (success, message) = await mqttOperate
                        .SendFaultInformationAsync(FaultData);
                AppendText($"故障代码:{fault.FaultCode},故障内容{fault.FaultDesc},上传状态：{message}");
            }
            catch (Exception ex)
            {
                string errorMsg = $"故障状态上传发生异常：{ex.Message}";
                NlogHelper.Default.Error(errorMsg);
                MessageHelper.MessageOK(errorMsg);
            }
        }
        #endregion


        List<double> DianNengCount = new List<double>();

        List<double> LiuLiangCount1 = new List<double>();
        List<double> LiuLiangCount2 = new List<double>();
        List<double> LiuLiangCount3 = new List<double>();
        List<double> LiuLiangCount4 = new List<double>();
        List<double> LiuLiangCount5 = new List<double>();
        List<double> LiuLiangCount6 = new List<double>();
        List<double> LiuLiangCount7 = new List<double>();
        private void Timer1_Tick(object sender, EventArgs e)
        {

            DianNengCount.Add(OPCHelper.AIgrp[18]);

            LiuLiangCount1.Add(OPCHelper.AIgrp[8]);
            LiuLiangCount2.Add(OPCHelper.AIgrp[9]);
            LiuLiangCount3.Add(OPCHelper.AIgrp[10]);
            LiuLiangCount4.Add(OPCHelper.AIgrp[11]);
            LiuLiangCount5.Add(OPCHelper.AIgrp[12]);
            LiuLiangCount6.Add(OPCHelper.AIgrp[13]);
            LiuLiangCount7.Add(OPCHelper.AIgrp[14]);
        }

        private void uiSwitch5_MouseDown(object sender, MouseEventArgs e)
        {
            (bool Result, string txt) = FrmText();
            if (!Result)
            {
                MessageHelper.MessageOK(txt, AntdUI.TType.Error);
                return;
            }
        }
    }
}