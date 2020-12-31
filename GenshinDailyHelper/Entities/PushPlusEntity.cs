using System;
using System.Threading;
using System.Threading.Tasks;
using GenshinDailyHelper.Exception;
using Newtonsoft.Json;

namespace GenshinDailyHelper.Entities
{
    public class PushPlusEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        public override string ToString()
        {
            return $"代码:{Code}\n消息:{Message}\n数据:{Data}\n数量{Count}";
        }

    }
}
