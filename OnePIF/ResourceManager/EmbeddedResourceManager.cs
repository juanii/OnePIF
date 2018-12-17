using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace OnePIF
{
    // https://stackoverflow.com/questions/1952638/single-assembly-multi-language-windows-forms-deployment-ilmerge-and-satellite-a
    public class EmbeddedResourceManager : ResourceManager
    {
        private CultureInfo neutralResourcesCulture;

        public EmbeddedResourceManager(string baseName, Assembly assembly) : base(baseName, assembly) { }

        protected override ResourceSet InternalGetResourceSet(CultureInfo requestedCulture, bool createIfNotExists, bool tryParents)
        {
            ResourceSet resourceSet = (ResourceSet)this.ResourceSets[requestedCulture];
            CultureInfo cultureInfo = null;

            if (resourceSet == null)
            {
                //lazy-load default language (without caring about duplicate assignment in race conditions, no harm done);
                if (this.neutralResourcesCulture == null)
                    this.neutralResourcesCulture = GetNeutralResourcesLanguage(this.MainAssembly);

                // if we're asking for the default language, then ask for the
                // invariant (non-specific) resources.
                if (neutralResourcesCulture.Equals(requestedCulture))
                    requestedCulture = CultureInfo.InvariantCulture;

                ResourceFallbackManager resourceFallbackManager = new ResourceFallbackManager(requestedCulture, this.neutralResourcesCulture, tryParents);
                foreach (CultureInfo item in resourceFallbackManager)
                {
                    lock (this.ResourceSets)
                    {
                        if ((resourceSet = (ResourceSet)this.ResourceSets[item.Name]) != null)
                        {
                            if (requestedCulture != item)
                                cultureInfo = item;

                            break;
                        }
                    }

                    string resourceFileName = GetResourceFileName(item);
                    using (Stream resourceStream = this.MainAssembly.GetManifestResourceStream(resourceFileName))
                    {
                        //If we found the appropriate resources in the local assembly
                        if (resourceStream != null)
                        {
                            resourceSet = new ResourceSet(resourceStream);
                            cultureInfo = item;
                            break;
                        }
                        else
                        {
                            resourceSet = base.InternalGetResourceSet(item, createIfNotExists, false);
                            if (resourceSet != null)
                                return resourceSet;
                        }
                    }
                }

                if (resourceSet != null && cultureInfo != null)
                {
                    foreach (CultureInfo item in resourceFallbackManager)
                    {
                        AddResourceSet(this.ResourceSets, item, ref resourceSet);
                        if (item == cultureInfo)
                            break;
                    }
                }
            }

            return resourceSet;
        }

        // Reimplementation of private method AddResourceSet of class System.Resources.ResourceManager in mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
        private static void AddResourceSet(Hashtable localResourceSets, CultureInfo culture, ref ResourceSet resourceSet)
        {
            lock (localResourceSets)
            {
                ResourceSet objA = (ResourceSet)localResourceSets[culture];

                if (objA != null)
                {
                    if (!object.Equals(objA, resourceSet))
                    {
                        resourceSet.Dispose();
                        resourceSet = objA;
                    }
                }
                else
                {
                    localResourceSets.Add(culture, resourceSet);
                }
            }
        }
    }
}