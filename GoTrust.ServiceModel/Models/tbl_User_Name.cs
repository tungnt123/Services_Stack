using ServiceStack;
using ServiceStack.DataAnnotations;
using System;

namespace GoTrust.ServiceModel
{
    public class Tbl_User_Name : AuditBase
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Identity_Card { get; set; }
        public DateTime Crate_Date { get; set; }
        public string Create_User { get; set; }
    }

    public class Query_User_Name : QueryDb<Tbl_User_Name>
    {
    
    }
    public class Create_User_Name : ICreateDb <Tbl_User_Name>, IReturn<IdResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Identity_Card { get; set; }
        public DateTime Crate_Date { get; set; }
        public string Create_User { get; set; }
    }
    public class Update_User_Name : IUpdateDb<Tbl_User_Name>, IReturn<IdResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Identity_Card { get; set; }
        public DateTime Crate_Date { get; set; }
        public string Create_User { get; set; }
    }
    public class Delete_User_Name : IUpdateDb<Tbl_User_Name>, IReturn<IdResponse>
    {
        public int Id { get; set; }

     
    }
}