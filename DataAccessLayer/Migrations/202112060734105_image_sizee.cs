﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_sizee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 250));
        }
    }
}
