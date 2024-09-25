using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core;

namespace Xml_to_BlockListItem.Services
{
    public class BlockListItem
    {
        public Guid contentTypeKey { get; set; }
        public Udi udi { get; set; }
        public string header { get; set; }
        public string date { get; set; }
        public BlockContent content { get; set; }
    }

    public class BlockContent
    {
        public string markup { get; set; }
        public BlockSubContent blocks { get; set; }
    }

    public class BlockSubContent
    {
        public List<object> contentData { get; set; } = new List<object>();
        public List<object> settingsData { get; set; } = new List<object>();
    }

    public class XmlImportService
    {
        public void CreateContentWithBlockList(IContentService contentService)
        {
            var content = contentService.Create("Announance", 1060, "announance");
            
            var blockListItems = new List<BlockListItem>();
            
            var announceContent = CreateBlockListItem(
                "Duyuru Başlığı", 
                "2024-09-24", 
                "<p>Duyuru İçeriği</p>"
            );
            
            blockListItems.Add(announceContent);
            
            var blockListJson = JsonConvert.SerializeObject(new 
            { 
                layout = new Dictionary<string, object> 
                { 
                    { "Umbraco.BlockList", new List<object>
                        {
                            new { contentUdi = announceContent.udi.ToString() } 
                        }
                    }
                },
                contentData = blockListItems,
                settingsData = new List<object>()
            });
            
            content.SetValue("xmlContent", blockListJson);
            
            contentService.SaveAndPublish(content);
        }

        private BlockListItem CreateBlockListItem(string header, string date, string markup)
        {
            var blockContent = new BlockContent
            {
                markup = markup,
                blocks = new BlockSubContent()
            };

            var blockListItem = new BlockListItem
            {
                contentTypeKey = new Guid("78392a16-1b1a-485b-aa98-2dec43ea3f6a"), 
                udi = Udi.Create("element", Guid.NewGuid()), 
                header = header,
                date = date,
                content = blockContent
            };

            return blockListItem;
        }
    }
}