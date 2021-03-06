using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;

namespace NCI.OCPL.Api.Glossary.Services
{
    /// <summary>
    /// Elasticsearch implementation of the service for retrieveing suggestions for
    /// GlossaryTerm objects.
    /// </summary>
    public class AutosuggestQueryService : IAutosuggestQueryService
    {

        private IElasticClient _elasticClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AutosuggestQueryService(IElasticClient client)
        {
            _elasticClient = client;
        }  

        /// <summary>
        /// Search for Terms based on the search criteria.
        /// <param name="dictionary">The value for dictionary.</param>
        /// <param name="audience">Patient or Healthcare provider</param>
        /// <param name="language">The language in which the details needs to be fetched</param>
        /// <param name="query">The search query</param>
        /// <returns>A list of GlossaryTerm</returns>        
        /// </summary>
        public async Task<List<GlossaryTerm>> getSuggestions(string dictionary, AudienceType audience, string language, string query)
        {
            // Temporary Solution till we have Elastic Search
            List<GlossaryTerm> glossaryTermList = new List<GlossaryTerm>();
            glossaryTermList.Add(GenerateSampleTerm());
            glossaryTermList.Add(GenerateSampleTerm());

            return glossaryTermList;
        }   

        /// <summary>
        /// This temporary method will create a GlossaryTerm
        /// object to testing purpose.
        /// </summary>
        /// <returns>The GlossaryTerm</returns>
        private GlossaryTerm GenerateSampleTerm(){
            GlossaryTerm _GlossaryTerm = new GlossaryTerm();
            Pronounciation pronounciation = new Pronounciation("Pronounciation Key", "pronunciation");
            Definition definition = new Definition("<html><h1>Definition</h1></html>", "Sample definition");
            _GlossaryTerm.Id = 7890L;
            _GlossaryTerm.Language = "EN";
            _GlossaryTerm.Dictionary = "Dictionary";
            _GlossaryTerm.Audience = AudienceType.Patient;
            _GlossaryTerm.TermName = "TermName";
            _GlossaryTerm.PrettyUrlName = "www.glossary-api.com";
            _GlossaryTerm.Pronounciation = pronounciation;
            _GlossaryTerm.Definition = definition;
            _GlossaryTerm.RelatedResources = new RelatedResourceType [] {RelatedResourceType.Summary , RelatedResourceType.DrugSummary};
            return _GlossaryTerm;
        }                     

    }
}