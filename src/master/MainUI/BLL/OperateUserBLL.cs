using MainUI.CurrencyHelper;

namespace MainUI.BLL
{
    internal class OperateUserBLL
    {
        public bool UpdateUserPwd(int ID, string pwd) => VarHelper.fsql.Update<OperateUserModel>()
                  .Set(o => o.Password, pwd)
                  .Where(o => o.ID == ID)
                  .ExecuteAffrows() > 0;

        [Obsolete("废弃工号，暂时预留")]
        public OperateUserModel SelectUserID(string JobNumber)
        {
            return VarHelper.fsql.Select<OperateUserModel>()
                .Where(a => a.JobNumber == JobNumber)
                .ToList()
                .FirstOrDefault();
        }

        public OperateUserModel SelectUser(OperateUserModel model)
        {
            return VarHelper.fsql.Select<OperateUserModel>()
                .Where(a => a.ID == model.ID)
                .ToList()
                .FirstOrDefault();
        }

        public bool UpdateUser(OperateUserModel model) => VarHelper.fsql.Update<OperateUserModel>()
                   .Set(a => a.JobNumber, model.JobNumber)
                   .Set(a => a.Username, model.Username)
                   .Set(a => a.Password, model.Password)
                   .Set(a => a.depId, model.depId)
                   .Set(a => a.depName, model.depName)
                   .Where(a => a.ID == model.ID)
                   .ExecuteAffrows() > 0;

        public bool AddUser(OperateUserModel model) => VarHelper.fsql.Insert(model).ExecuteAffrows() > 0;

        public OperateUserModel GetJobNumber(OperateUserModel model) => VarHelper.fsql
            .Select<OperateUserModel>()
            .Where(a => a.ID == model.ID)
            .First();

        public bool ModifyOrAddUserTable(OperateUserModel model)
        {
            var data = GetJobNumber(model);
            return data != null ? UpdateUser(model) : AddUser(model);
        }

        public List<OperateUserModel> GetUsers(string name = null) => VarHelper.fsql.Select<OperateUserModel>()
            .WhereIf(!string.IsNullOrEmpty(name), a => a.Username == name).ToList();

        public int RemoveByUserJob(OperateUserModel model) => VarHelper.fsql.Delete<OperateUserModel>()
            .Where(a => a.ID == model.ID)
            .ExecuteAffrows();

        public int UpdateUserID(OperateUserModel model) => VarHelper.fsql.Update<OperateUserModel>()
                   .Set(a => a.JobNumber, model.JobNumber)
                   .Set(a => a.Username, model.Username)
                   .Set(a => a.Permission, model.Permission)
                   .Set(a => a.depName, model.depName)
                   .Where(a => a.ID == model.ID)
                   .ExecuteAffrows();

        // 手动添加时
        public bool HandMovementUserTable(OperateUserModel model)
        {
            var data = GetJobNumber(model);
            return data != null ? HandUpdateUser(model) : AddUser(model);
        }

        public bool HandUpdateUser(OperateUserModel model) => VarHelper.fsql.Update<OperateUserModel>()
               .Set(a => a.Username, model.Username)
               .Set(a => a.depId, model.depId)
               .Set(a => a.Permission, model.Permission)
               .Where(a => a.ID == model.ID)
               .ExecuteAffrows() > 0;

    }
}
