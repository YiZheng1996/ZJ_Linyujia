using MainUI.CurrencyHelper;

namespace MainUI.BLL
{
    public class ModelBLL : DriverDeviceBaseBLL
    {
        protected override void Init()
        {
            this.TableName = "Model";
            base.Init();
        }

        public DataTable GetAllModelType()
        {
            string sql = "select ID, ModelType,mark from ModelTypeTable order by ID ";
            return this.GetDataTable(sql);
        }
        public bool IsExist(string mc)
        {
            string sql = string.Format("select ModelType from ModelTypeTable where ModelType='{0}'", mc);
            DataTable ds = this.GetDataTable(sql);
            if (ds.Rows.Count > 0)
            {

                return true;
            }
            else
                return false;
        }
        public bool IsExist(string mc, string bz)
        {
            string sql = string.Format("select ModelType from ModelTypeTable where ModelType='{0}',mark='{1}'", mc, bz);
            DataTable ds = this.GetDataTable(sql);
            if (ds.Rows.Count > 0)
            {

                return true;
            }
            else
                return false;
        }

        public bool Add(string name, string bz)
        {
            NewFile(SpecificSymbol(name));
            string sql = string.Format(@"insert into ModelTypeTable (ModelType,mark) values ('{0}','{1}')", name, bz);
            return Connection.ExecuteNonQuery(sql) >= 1;
        }
        public bool Delete(string name, int id)
        {
            deleteFile(SpecificSymbol(name));
            string sql = string.Format(@"delete from ModelTypeTable where ID={0}", id);
            return Connection.ExecuteNonQuery(sql) >= 1;
        }
        public bool Updata(int id, string name, string bz, string OldName)
        {
            changeFileName(SpecificSymbol(name), SpecificSymbol(OldName));
            string sql = string.Format(@"update ModelTypeTable set ModelType='{0}',mark='{1}' where ID={2}", name, bz, id);
            return Connection.ExecuteNonQuery(sql) >= 1;

        }
        void NewFile(string newName)
        {
            string rootDirectory = Application.StartupPath + "\\proc\\";
            bool s = AddFileName(rootDirectory + newName, false);
        }
        public bool AddFileName(string newFile, bool isFile)
        {
            if (isFile && !File.Exists(newFile))
            {
                File.Create(newFile);
            }

            if (!isFile && !Directory.Exists(newFile))
            {
                Directory.CreateDirectory(newFile);
            }

            return true;
        }
        void deleteFile(string filename)
        {
            string rootDirectory = Application.StartupPath + "\\proc\\";
            string path = rootDirectory + filename;
            bool s = DelFileName(path);
        }
        public bool DelFileName(string fileName)
        {
            try
            {
                if (Directory.Exists(fileName))
                {
                    Directory.Delete(fileName, true);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        void changeFileName(string filename, string oldname)
        {
            string rootDirectory = Application.StartupPath + "\\proc\\";
            string path = rootDirectory + oldname;
            if (!System.IO.Directory.Exists(path))
                Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(path, filename);
        }

        public string SpecificSymbol(string gg)
        {
            while (true)
            {
                if (gg.IndexOf('%') > -1)
                {
                    int i = gg.IndexOf('%');
                    string a = gg[..i];
                    string b = gg.Substring(i + 1, gg.Length - i - 1);
                    gg = a + b;
                }
                else if (gg.IndexOf(':') > -1)
                {
                    int i = gg.IndexOf(':');
                    string a = gg.Substring(0, i);
                    string b = gg.Substring(i + 1, gg.Length - i - 1);
                    gg = a + b;
                }
                else if (gg.IndexOf('/') > -1)
                {
                    int i = gg.IndexOf('/');
                    string a = gg[..i];
                    string b = gg.Substring(i + 1, gg.Length - i - 1);
                    gg = a + b;
                }
                else
                {
                    break;
                }
            }
            return gg;
        }

        public List<ModelsType> GetModels()
        {
            return VarHelper.fsql.Select<ModelsType>().ToList();
        }

        public List<Models> GetAllModels()
        {
            return VarHelper.fsql.Select<Models>().ToList();
        }

        public List<NewModels> GetNewModels()
        {
            return VarHelper.fsql.Select<Models, ModelsType>()
                .LeftJoin((m, t) => m.TypeID == t.ID)
                //.Where((m, t) => m.TypeID == t.ID)
                .ToList((m, t) => new NewModels
                {
                    ModelTypeID = t.ID,
                    ModelType = t.ModelType,
                });
        }
    }
}
