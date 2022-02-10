﻿using KS3.Http;
using KS3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace KS3.Transform
{
    class GetBucketLocationResultUnmarshaller : IUnmarshaller<GetBucketLocationResult, Stream>
    {
        public GetBucketLocationResult Unmarshall(Stream input)
        {
            GetBucketLocationResult result = new GetBucketLocationResult();
            XDocument doc = XDocument.Load(input);
            var xml = doc.Elements();
            var regions=xml.First().Elements().Where(w => w.Name == "LocationConstraint").ToList();
            foreach(var region in regions){
                result.Region = (Region)Enum.Parse(typeof(Region), region.ToString());
            }
            return result;
        }
    }
}
