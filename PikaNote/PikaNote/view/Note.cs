using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikaNote.view
{
    public class Note
    {
        public int Id { get; set;  }
        public String Title { get; set; }
        public String TinhTrang { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaDN { get; set; }
        public String Content { get; set; }

        public Note() { }
        public Note(int Id, String Title, String TinhTrang, DateTime NgayTao, int MaDN, String Content) 
        {
            this.Id = Id;
            this.Title = Title;
            this.TinhTrang = TinhTrang;
            this.NgayTao = NgayTao;
            this.MaDN = MaDN;
            this.Content = Content;
        }
    }
}