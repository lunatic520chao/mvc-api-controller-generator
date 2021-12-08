using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace mvcwithSqliteDemo.Sql.Entities
{
    [Table("t_depart_test")]
    public class DepartMember
    {
        #region attributes
        [Column("FID")]
        public int Id {get;set;}
        [Column("fmember_name")]
        public string name { get; set;} 
        [Column("fage")]
        public int age { get; set;} 
        [Column("fcomment")]
        public string comment { get; set;}
        #endregion
    }
}