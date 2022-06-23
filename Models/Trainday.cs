using System;
using System.Collections.Generic;

namespace TRAIN_MASTER_WITH_DB_1ST_APPROACH.Models
{
    public partial class Trainday
    {
        public int TrainNo { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
    }
}
