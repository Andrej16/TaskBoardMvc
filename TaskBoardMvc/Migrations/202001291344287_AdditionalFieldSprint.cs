namespace TaskBoardMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalFieldSprint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkItems", "Sprint", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkItems", "Sprint");
        }
    }
}
