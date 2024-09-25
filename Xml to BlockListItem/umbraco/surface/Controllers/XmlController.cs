using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Core.Services;
using Xml_to_BlockListItem.Services;

namespace WarrantyWeb.Controllers
{
    [Route("api/xml")]
    public class XmlController : UmbracoController
    {
        private readonly IContentService _contentService;
        private readonly XmlImportService _xmlImportService;

        public XmlController(IContentService contentService, XmlImportService xmlImportService)
        {
            _contentService = contentService;
            _xmlImportService = xmlImportService;
        }

        [HttpGet("import")]
        public IActionResult ImportXml()
        {
            // XML içeriği oluşturma işlemi
            _xmlImportService.CreateContentWithBlockList(_contentService);
            return Ok("İçerikler başarıyla oluşturuldu.");
        }
    }
}
