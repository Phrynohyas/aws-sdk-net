﻿/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;
using Amazon.Util;

using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime
{
    /// <summary>
    /// This class is the base class of all the configurations settings to connect
    /// to a service.
    /// </summary>    
    public abstract partial class ClientConfig
    {
        private string proxyHost;
        private int proxyPort = -1;

        static ClientConfig()
        {
            NameValueCollection appConfig = ConfigurationManager.AppSettings;
            var regionName = appConfig[APP_CONFIG_REGION_KEY];
            if (string.IsNullOrEmpty(regionName))
            {
                DEFAULT_REGION = RegionEndpoint.USEast1;
                return;
            }

            DEFAULT_REGION = RegionEndpoint.GetBySystemName(regionName);
            if (DEFAULT_REGION == null)
                throw new ArgumentException("Region {0} specified in the app.config is not a valid region name", regionName);
        }

        private int? connectionLimit;
        private bool useNagleAlgorithm = false;

        /// <summary>
        /// Gets and sets of the ProxyHost property.
        /// </summary>
        public string ProxyHost
        {
            get { return this.proxyHost; }
            set { this.proxyHost = value; }
        }

        /// <summary>
        /// Gets and sets of the ProxyPort property.
        /// </summary>
        public int ProxyPort
        {
            get { return this.proxyPort; }
            set { this.proxyPort = value; }
        }

        /// <summary>
        /// Gets and sets the connection limit set on the ServicePoint for the WebRequest.
        /// Default value is 50 connections unless ServicePointManager.DefaultConnectionLimit is set in 
        /// which case ServicePointManager.DefaultConnectionLimit will be used as the default.
        /// </summary>
        public int ConnectionLimit
        {
            get { return AWSSDKUtils.GetConnectionLimit(this.connectionLimit); }
            set { this.connectionLimit = value; }
        }

        /// <summary>
        /// Gets or sets a Boolean value that determines whether the Nagle algorithm is used on connections managed by the ServicePoint object used
        /// for requests to AWS.  This is defaulted to false for lower latency with responses that return small amount of data.  This is the opposite 
        /// default then ServicePoint.UseNagleAlgorithm which is optimized for large responses like web pages or images.
        /// </summary>
        public bool UseNagleAlgorithm
        {
            get { return this.useNagleAlgorithm; }
            set { this.useNagleAlgorithm = value; }
        }
    }
}