namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;

    public partial class addcolumn : DbMigration
    {
        public override void Up()
        {
           AddColumn("dbo.tb_ProductImage", "PublicId", c => c.String());

        }
        
        public override void Down()
        {
            
        }
    }
}
