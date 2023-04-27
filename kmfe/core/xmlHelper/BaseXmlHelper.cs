namespace kmfe.core.xmlHelper
{
    public abstract class BaseXmlHelper
    {
        protected readonly ScenarioData scenarioData;

        public BaseXmlHelper(ScenarioData scenarioData)
        {
            this.scenarioData = scenarioData;
        }

        public abstract void Load(string xmlPath);

        public abstract void Save(string xmlPath);
    }
}
