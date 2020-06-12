using DomainLibrary.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
   public partial class DBVullen : DbContext
    {
        public virtual DbSet<CyclingSession> CyclingSessions { get; set; }
        public virtual DbSet<TrainingManager> TrainingManagers { get; set; }
    }
}
