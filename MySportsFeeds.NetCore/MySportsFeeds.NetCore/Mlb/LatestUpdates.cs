﻿using System;
using System.Threading.Tasks;
using MySportsFeeds.NetCore.Enums;
using MySportsFeeds.NetCore.Helpers;
using MySportsFeeds.NetCore.Models.Mlb;
using MySportsFeeds.NetCore.Workers;

namespace MySportsFeeds.NetCore.Mlb
{
    /// <summary>
    /// 
    /// </summary>
    public class LatestUpdates
    {
        /// <summary>
        /// The URL
        /// </summary>
        private const string Url = "/pull/mlb/{0}/latest_updates.json";

        /// <summary>
        /// The HTTP worker
        /// </summary>
        private HttpCommunicationWorker _httpWorker;

        /// <summary>
        /// Initializes a new instance of the <see cref="LatestUpdates"/> class.
        /// </summary>
        /// <param name="httpWorker">The HTTP worker.</param>
        internal LatestUpdates(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        /// <summary>
        /// Gets the Latest Updates.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <param name="year">The year.</param>
        /// <param name="seasonType">Type of the season.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns></returns>
        public async Task<LastUpdatesReponse> Get(int year, SeasonType seasonType, RequestOptions requestOptions = null)
        {
            var url = string.Concat(_httpWorker.Version, Url);
            string requestUrl = UrlBuilder.FormatRestApiUrl(url, year, seasonType, requestOptions);

            return await _httpWorker.GetAsync<LastUpdatesReponse>(requestUrl).ConfigureAwait(false);
        }
    }
}