using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TaskBoardMvc.Models
{
    public class WorkItem
    {
        public int Id { get; set; }
        [Display(Name = "Номер задачи")]
        public int TfsNum { get; set; }
        public string TfsName { get; set; }
        public string UsedItems_Changed { get; set; }
        public string UsedItems_New { get; set; }
        public string TfsUrl { get; set; }
        public int? BackupId { get; set; }
        [Display(Name = "Date update")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; }
        public int? Sprint { get; set; }
    }
    public class WorkItemDbContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
    }
}