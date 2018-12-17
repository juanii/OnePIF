using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace OnePIF
{
    // Reimplementation of internal class System.Resources.ResourceFallbackManager in mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    public class ResourceFallbackManager : IEnumerable<CultureInfo>, IEnumerable
    {
        private CultureInfo m_neutralResourcesCulture;

        private CultureInfo m_startingCulture;

        private bool m_useParents;

        internal ResourceFallbackManager(CultureInfo startingCulture, CultureInfo neutralResourcesCulture, bool useParents)
        {
            if (startingCulture != null)
            {
                m_startingCulture = startingCulture;
            }
            else
            {
                m_startingCulture = CultureInfo.CurrentUICulture;
            }
            m_neutralResourcesCulture = neutralResourcesCulture;
            m_useParents = useParents;
        }

        public IEnumerator<CultureInfo> GetEnumerator()
        {
            bool reachedNeutralResourcesCulture = false;
            CultureInfo currentCulture = m_startingCulture;
            do
            {
                if (m_neutralResourcesCulture != null && currentCulture.Name == m_neutralResourcesCulture.Name)
                {
                    yield return CultureInfo.InvariantCulture;
                    reachedNeutralResourcesCulture = true;
                    break;
                }
                yield return currentCulture;
                currentCulture = currentCulture.Parent;
            }
            while (m_useParents && !currentCulture.Name.Equals(CultureInfo.InvariantCulture.Name));
            if (m_useParents && !m_startingCulture.Name.Equals(CultureInfo.InvariantCulture.Name) && !reachedNeutralResourcesCulture)
            {
                yield return CultureInfo.InvariantCulture;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
