using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace jumpPochinkiBot
{
	//SeasonID Part
	public class SeasonsData
	{
		public List<SeasonDataInfo> data { get; set; }
	}
	public class SeasonDataInfo
	{
		public string type { get; set; }
		public string id { get; set; }
		public Attributes attributes { get; set; }
	}
	public class Attributes
	{
		public bool isCurrentSeason { get; set; }
		public bool isOffseason { get; set; }
	}

	public class SeasonID
	{
		public static string GetCurrentSeasonID(string json)
		{
			//string json = "{\"data\":[{\"type\":\"season\",\"id\":\"division.bro.official.2017-beta\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre1\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre2\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre3\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre4\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre5\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre6\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre7\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre8\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2017-pre9\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-01\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-02\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-03\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-04\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-05\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-06\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-07\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-08\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.2018-09\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-01\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-02\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-03\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-04\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-05\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-06\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-07\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-08\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-09\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-10\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-11\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-12\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-13\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-14\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-15\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-16\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-17\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-18\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-19\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-20\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.pc-2018-21\",\"attributes\":{\"isCurrentSeason\":true,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-03\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-04\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-05\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-06\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-07\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-08\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-09\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-10\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-11\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-12\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-13\",\"attributes\":{\"isOffseason\":false,\"isCurrentSeason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-14\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-15\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-16\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-17\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-18\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-19\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-20\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}},{\"type\":\"season\",\"id\":\"division.bro.official.console-21\",\"attributes\":{\"isCurrentSeason\":false,\"isOffseason\":false}}],\"links\":{\"self\":\"https://api.pubg.com/shards/steam/seasons\"},\"meta\":{}}";
			var seasonsDatas = JsonSerializer.Deserialize<SeasonsData>(json);
			for (int i = 0; i < seasonsDatas.data.Count; i++)
			{
				if (seasonsDatas.data[i].attributes.isCurrentSeason == true)
				{
					var seasonID = seasonsDatas.data[i].id;
					return seasonID;
				}
			}
			return null;
		}
	}
}
