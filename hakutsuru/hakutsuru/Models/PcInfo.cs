using System.Net;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace hakutsuru.Models
{
    /// <summary>
    /// PC管理情報
    /// </summary>
    public class PcInfo
    {
        [Key]
        public string ControlNumber { get; set; }   //!< PC管理番号
        [Key]
        public IPAddress IpAddress  { get; set; }   //!< 固定IPアドレス
        public int Use              { get; set; }   //!< 使用区分(サーバ：0、個人：1、共有：2)
        public string Type          { get; set; }   //!< 機種
        public string ModelNumber   { get; set; }   //!< 型番
        public string UserName      { get; set; }   //!< 使用者名
        public string PcName        { get; set; }   //!< PC名
        public string Remarks1      { get; set; }   //!< 備考1 (60文字)
        public string Remarks2      { get; set; }   //!< 備考2 (60文字)
    }

    /// <summary>
    /// PC管理情報データベース
    /// </summary>
    public class PcInfoDBContext : DbContext
    {
        public DbSet<PcInfo> PcInfos { get; set; }
    }
}