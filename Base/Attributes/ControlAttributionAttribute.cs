﻿//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Reflection;
using CodeStack.SwEx.PMPage.Data;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.PMPage.Attributes
{
    /// <summary>
    /// Provides additional attribution options (i.e. icons, labels, tooltips etc.) for all controls
    /// </summary>
    /// <remarks>Can be applied to any property which is bound to the property manager page control</remarks>
    public class ControlAttributionAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Control label as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swcontrolbitmaplabeltype_e.html">swControlBitmapLabelType_e Enumeration</see>
        /// </summary>
        /// <remarks>0 for not bitmap</remarks>
        internal swControlBitmapLabelType_e StandardIcon { get; private set; } = 0;

        internal ControlIcon Icon { get; private set; }

        /// <param name="standardIcon">Control label as defined in <see href="http://help.solidworks.com/2016/english/api/swconst/solidworks.interop.swconst~solidworks.interop.swconst.swcontrolbitmaplabeltype_e.html">swControlBitmapLabelType_e Enumeration</see></param>
        public ControlAttributionAttribute(swControlBitmapLabelType_e standardIcon)
        {
            StandardIcon = standardIcon;
        }

        public ControlAttributionAttribute(Type resType, string iconResName)
        {
            Icon = new ControlIcon(ResourceHelper.GetResource<Image>(resType, iconResName));
        }

        public ControlAttributionAttribute(Type resType, string iconResName, string maskResName)
        {
            Icon = new ControlIcon(
                ResourceHelper.GetResource<Image>(resType, iconResName),
                ResourceHelper.GetResource<Image>(resType, maskResName));
        }
    }
}
