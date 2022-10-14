using System.ComponentModel.DataAnnotations;

namespace BlogAlternative.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AbouID { get; set; }
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
        public string AboutLocation { get; set; }
        public bool AboutStatus { get; set; }
    }
}
