﻿namespace BlogAlternative.EntityLayer.Concrete
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageURL { get; set; }
        public string Role { get; set; }
    }
}
