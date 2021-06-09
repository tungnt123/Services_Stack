using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoTrust.ServiceModel.Models
{
    [Table("UserProfile")]
    public class dto_Test
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public int Appid { get; set; }

        [Required]
        [StringLength(100)]
        public string Users_Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Pass_Word { get; set; }
        [Required]
        [StringLength(500)]
        public string Phone { get; set; }

        public DateTime Create_Date { get; set; }

        // public DateTime EndDate { get; set; }
        // public int Limit { get; set; } = 12;
    }



    [Route("/Test_Api/{Id*}", "GET")]
    public class Get_ID_User : IReturn<GetUserResponse>
    {
        public int Id { get; set; }
    }

    public class GetUserResponse
    {
        public List<dto_Test> Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; } // inject structured errors
    }
    [Route("/Test/{Appid}/{Users_Name}/{Pass_Word}/{Phone*}")]
    public class Inser_User : IReturn<Result_Insert>
    {
        public int Appid { get; set; }
        public string Users_Name { get; set; }
        public string Pass_Word { get; set; }
        public string Phone { get; set; }
    }
    public class Result_Insert
    {
        public dto_Test data { get; set; }
        public ResponseStatus ResponseStatus { get; set; }

    }
}
