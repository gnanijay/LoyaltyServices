
using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LoyaltyDBContext : DbContext
    {
        public LoyaltyDBContext()
            : base(DBHelper.GetLoyaltyConnectionString())
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public LoyaltyDBContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reward>().MapToStoredProcedures(r =>  
                 r.Insert(u => u.HasName("FDP_CUSTOMER_INSERT").Parameter(b => b.RewardId, "RewardId"))
                  .Update(sp=>sp.HasName("FDP_REWARD_UPDATE").Parameter(b=>b.RewardId, "RewardIdInput")
                                                             .Parameter(b=>b.Status, "StatusInput")
                                                             .Parameter(b=>b.RedeemDate, "RedeemDateInput"))
                  .Delete(u => u.HasName("FDP_REWARD_DELETE").Parameter(b => b.RewardId, "RewardIdInput"))
                  .Insert(u => u.HasName("FDP_REWARD_INSERT2").Parameter(b => b.RewardId, "RewardId")
                                                             .Parameter(b=>b.TDate, "TriggerDate")
                                                             ));

        }

        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<VCustomerRewards> VCustomerRewards { get; set; }
        public virtual DbSet<RewardType> RewardTypes { get; set; }
        public virtual DbSet<LoyalityRollout> LoyalityRollouts { get; set; }

    }
}