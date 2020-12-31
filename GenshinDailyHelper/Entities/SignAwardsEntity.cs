using System.Collections.Generic;
using Newtonsoft.Json;

namespace GenshinDailyHelper.Entities
{
    /// <summary>
    /// 签到奖励
    /// </summary>
    public class SignAwardsEntity : RootEntity<SignAwardsData>
    {

    }

    public class SignAwardsData
    {
        /// <summary>
        /// 签到月份
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; set; }
        /// <summary>
        /// 奖励信息
        /// </summary>
        [JsonProperty("awards")]
        public List<SignAwardsListItem> Awards { get; set; } = new List<SignAwardsListItem>();
    }

    public class SignAwardsListItem
    {
        /// <summary>
        /// 奖品图标
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        /// <summary>
        /// 奖品名字
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        public override string ToString()
        {
            return $"奖励:{Name} * {Cnt}\n";
        }
    }

}
