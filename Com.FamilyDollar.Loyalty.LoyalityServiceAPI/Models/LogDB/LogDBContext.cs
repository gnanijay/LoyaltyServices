using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models.LogDB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LogDBContext :DbContext
    {
        public LogDBContext()
            : base(DBHelper.GetLogDBConnectionString())
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public LogDBContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActivityLog>().MapToStoredProcedures(r =>
                 r.Insert(u => u.HasName("FDT_ACTIVITY_LOG_INSERT").Parameter(b => b.CId, "CId")
                                                                   .Parameter(b=>b.RewardId, "RewardId")
                                                                   .Parameter(b => b.TriggerId, "TriggerId")
                                                                   .Parameter(b => b.ErrorFlag, "ErrorFlag")
                                                                   .Parameter(b => b.ActivityDate, "ActivityDate")
                                                                   .Parameter(b => b.Activity, "Activity")
                 ));

        }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
    }
}