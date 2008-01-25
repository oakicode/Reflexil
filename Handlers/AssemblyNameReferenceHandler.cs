﻿/*
    Reflexil .NET assembly editor.
    Copyright (C) 2007 Sebastien LEBRETON

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#region " Imports "
using System;
using System.Windows.Forms;
using Mono.Cecil;
using Reflector.CodeModel;
using Reflexil.Utils;
#endregion

namespace Reflexil.Handlers
{
	public partial class AssemblyNameReferenceHandler: UserControl, IHandler
    {

        #region " Methods "
        public AssemblyNameReferenceHandler()
		{
			InitializeComponent();
		}

        bool IHandler.IsItemHandled(object item)
        {
            return (item) is IAssemblyReference && (item as IAssemblyReference).Context != null;
        }

        string IHandler.Label
        {
            get {
                return "Assembly reference";
            }
        }

        void IHandler.HandleItem(object item)
        {
            IAssemblyReference aref = item as IAssemblyReference;
            HandleItem(CecilHelper.ReflectorAssemblyReferenceToCecilAssemblyNameReference(aref));
        }

        void HandleItem(AssemblyNameReference anref)
        {
            NameReference.Bind(anref);
        }

        void IHandler.OnConfigurationChanged(object sender, EventArgs e)
        {
        }
        #endregion
        
    }
}