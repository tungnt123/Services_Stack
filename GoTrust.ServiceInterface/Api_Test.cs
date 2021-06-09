using GoTrust.ServiceModel.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;

namespace GoTrust.ServiceInterface
{
   public class Api_Test : Service
    {
        public object Post(Inser_User insert)
        {
            try
            {

                var data_request = new dto_Test
                {
                    Appid = insert.Appid,
                    Pass_Word = insert.Pass_Word,
                    Phone = insert.Phone,
                    Users_Name = insert.Users_Name,
                    Create_Date = DateTime.Now

                };
                Db.Save(data_request, references: true);
                var data = Db.Select<dto_Test>(x => x.Appid == insert.Appid);
                var rs = new dto_Test
                {
                    Id = data.FirstOrDefault().Id,
                    Appid = data.FirstOrDefault().Appid,
                    Phone = data.FirstOrDefault().Phone,
                    Pass_Word = data.FirstOrDefault().Pass_Word,
                    Users_Name = data.FirstOrDefault().Users_Name,
                    Create_Date = data.FirstOrDefault().Create_Date
                };

                return new Result_Insert
                {
                    data = rs,
                    //ResponseStatus = new 
                };
            }
            catch (Exception ex)
            {
                return new ResponseStatus
                {
                    ErrorCode = typeof(ArgumentException).Name,
                    Message = ex.Message,

                };
            }
        }
    }
}
