namespace TaskBoardMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkItems", "BackupId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkItems", "BackupId", c => c.Int(nullable: false));
        }
    }
}
