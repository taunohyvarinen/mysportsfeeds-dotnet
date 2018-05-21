﻿using System.Threading.Tasks;

using MySportsFeeds.NetCore.Enums;
using MySportsFeeds.NetCore.Helpers;
using MySportsFeeds.NetCore.Models;
using MySportsFeeds.NetCore.Workers;

namespace MySportsFeeds.NetCore.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class GamePlayByPlay
    {
        /// <summary>
        /// The URL
        /// </summary>
        private const string Url = "v1.2/pull/{0}/{1}//game_playbyplay.json";

        /// <summary>
        /// The HTTP worker
        /// </summary>
        private HttpCommunicationWorker _httpWorker;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePlayByPlay"/> class.
        /// </summary>
        /// <param name="httpWorker">The HTTP worker.</param>
        internal GamePlayByPlay(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        /// <summary>
        /// Gets the specified league.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <param name="year">The year.</param>
        /// <param name="seasonType">Type of the season.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns></returns>
        public async Task<GamePlayByPlayResponse> Get(League league, int year, SeasonType seasonType, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(Url, league, year, seasonType, requestOptions);

            return await _httpWorker.GetAsync<GamePlayByPlayResponse>(requestUrl).ConfigureAwait(false);
        }
    }
}
