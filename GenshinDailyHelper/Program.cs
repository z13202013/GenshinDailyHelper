using System.Linq;
using GenshinDailyCheckIn.Client;
using GenshinDailyCheckIn.Constant;
using GenshinDailyCheckIn.Entities;
using GenshinDailyCheckIn.Exception;
using System.Threading.Tasks;

namespace GenshinDailyCheckIn
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLineUtil.WriteLineLog("开始签到");

            try
            {
                if (args.Length <= 0)
                {
                    WriteLineUtil.WriteLineLog("获取参数不对");
                    System.Console.ReadLine();
                    return;
                }

                var cookieString = string.Join(' ',args);

                var cookies = cookieString.Split("#");

                int accountNum = 1;

                foreach (var cookie in cookies)
                {
                    WriteLineUtil.WriteLineLog($"开始签到 账号{accountNum++}");

                    var client = new GenShinClient(
                        cookie);

                    var rolesResult =
                        await client.GetExecuteRequest<UserGameRolesEntity>(Config.GetUserGameRolesByCookie,
                            "game_biz=hk4e_cn");

                    //检查第一步获取账号信息
                    rolesResult.CheckOutCodeAndSleep();

                    WriteLineUtil.WriteLineLog(rolesResult.Data.List[0].ToString());

                    var roles = rolesResult.Data.List[0];

                    var signDayResult = await client.GetExecuteRequest<SignDayEntity>(Config.GetBbsSignRewardInfo,
                        $"act_id={Config.ActId}&region={roles.Region}&uid={roles.GameUid}");

                    //检查第二步是否签到
                    signDayResult.CheckOutCodeAndSleep();

                    WriteLineUtil.WriteLineLog(signDayResult.Data.ToString());

                    if (signDayResult.Data.IsSign)
                    {
                        continue;
                    }

                    var data = new
                    {
                        act_id = Config.ActId,
                        region = roles.Region,
                        uid = roles.GameUid
                    };

                    var result =
                        await client.PostExecuteRequest<SignResultEntity>(Config.PostSignInfo,
                            jsonContent: new JsonContent(data));

                    WriteLineUtil.WriteLineLog(result.CheckOutCodeAndSleep());
                }
            }
            catch (GenShinException e)
            {
                WriteLineUtil.WriteLineLog(e.Message);
            }
            catch (System.Exception e)
            {
                WriteLineUtil.WriteLineLog(e);
            }

            WriteLineUtil.WriteLineLog("签到结束");
            System.Console.ReadLine();
        }
    }
}
