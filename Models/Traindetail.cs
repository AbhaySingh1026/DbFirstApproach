using System;
using System.Collections.Generic;

namespace TRAIN_MASTER_WITH_DB_1ST_APPROACH.Models
{
    public partial class Traindetail
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; } = null!;
        public string FromStation { get; set; } = null!;
        public string ToStation { get; set; } = null!;
        public TimeSpan JourneyStartTime { get; set; }
        public TimeSpan JourneyEndTime { get; set; }

        public virtual Trainday Trainday { get; set; } = null!;
    }
}
