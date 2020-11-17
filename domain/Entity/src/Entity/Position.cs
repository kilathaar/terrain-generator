using System;

namespace Domain.Entity {
	public class Position {
		private float _x;
		private float _y;
		private float _z;
		public Position(float x, float y, float z) {
			this._x = x;
			this._y = y;
			this._z = z;
		}

		public float x => _x;
		public float y => _y;
		public float z => _z;
	}
}
