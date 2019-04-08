using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0]")]
	public partial class ConnectedTextNetworkObject : NetworkObject
	{
		public const int IDENTITY = 7;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		[ForgeGeneratedField]
		private char _text;
		public event FieldEvent<char> textChanged;
		public Interpolated<char> textInterpolation = new Interpolated<char>() { LerpT = 0f, Enabled = false };
		public char text
		{
			get { return _text; }
			set
			{
				// Don't do anything if the value is the same
				if (_text == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_text = value;
				hasDirtyFields = true;
			}
		}

		public void SettextDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_text(ulong timestep)
		{
			if (textChanged != null) textChanged(_text, timestep);
			if (fieldAltered != null) fieldAltered("text", _text, timestep);
		}
		[ForgeGeneratedField]
		private int _players;
		public event FieldEvent<int> playersChanged;
		public Interpolated<int> playersInterpolation = new Interpolated<int>() { LerpT = 0f, Enabled = false };
		public int players
		{
			get { return _players; }
			set
			{
				// Don't do anything if the value is the same
				if (_players == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_players = value;
				hasDirtyFields = true;
			}
		}

		public void SetplayersDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_players(ulong timestep)
		{
			if (playersChanged != null) playersChanged(_players, timestep);
			if (fieldAltered != null) fieldAltered("players", _players, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			textInterpolation.current = textInterpolation.target;
			playersInterpolation.current = playersInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _text);
			UnityObjectMapper.Instance.MapBytes(data, _players);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_text = UnityObjectMapper.Instance.Map<char>(payload);
			textInterpolation.current = _text;
			textInterpolation.target = _text;
			RunChange_text(timestep);
			_players = UnityObjectMapper.Instance.Map<int>(payload);
			playersInterpolation.current = _players;
			playersInterpolation.target = _players;
			RunChange_players(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _text);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _players);

			// Reset all the dirty fields
			for (int i = 0; i < _dirtyFields.Length; i++)
				_dirtyFields[i] = 0;

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (textInterpolation.Enabled)
				{
					textInterpolation.target = UnityObjectMapper.Instance.Map<char>(data);
					textInterpolation.Timestep = timestep;
				}
				else
				{
					_text = UnityObjectMapper.Instance.Map<char>(data);
					RunChange_text(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (playersInterpolation.Enabled)
				{
					playersInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					playersInterpolation.Timestep = timestep;
				}
				else
				{
					_players = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_players(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (textInterpolation.Enabled && !textInterpolation.current.UnityNear(textInterpolation.target, 0.0015f))
			{
				_text = (char)textInterpolation.Interpolate();
				//RunChange_text(textInterpolation.Timestep);
			}
			if (playersInterpolation.Enabled && !playersInterpolation.current.UnityNear(playersInterpolation.target, 0.0015f))
			{
				_players = (int)playersInterpolation.Interpolate();
				//RunChange_players(playersInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public ConnectedTextNetworkObject() : base() { Initialize(); }
		public ConnectedTextNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public ConnectedTextNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}
