﻿namespace mongodb.Repository.Entities
{
    public class MongoCnn
    {
        public string connectionString { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
