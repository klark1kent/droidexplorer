using System;
using System.Collections.Generic;
using System.Text;

namespace DroidExplorer.Core.IO {
	public class FileInfo : FileSystemInfo {
		internal FileInfo ( string name, long size, Permission userPermission, Permission groupPermission, Permission otherPermission, DateTime lastMod, bool isExec, string fullPath )
			: base ( name, size, userPermission, groupPermission, otherPermission, lastMod, isExec, fullPath ) {

		}

		public override bool IsDirectory {
			get { return false; }
			protected set { return; }
		}

		public override bool IsLink {
			get { return false; }
			protected set { return; }
		}

		public static FileInfo Create ( System.IO.FileInfo fi ) {
			FileInfo result = new FileInfo ( fi.Name, fi.Length, new Permission ( "rwx" ), new Permission ( "rwx" ), new Permission ( "rwx" ), fi.LastWriteTime, false, string.Format ( "/{0}", fi.Name ) );
			return result;
		}

		public static FileInfo Create ( string name, long size, Permission userPermission, Permission groupPermission, Permission otherPermission, DateTime lastMod, bool isExec, string fullPath ) {
			return new FileInfo ( name, size, userPermission, groupPermission, otherPermission, lastMod, isExec, fullPath );
		}
	}
}
