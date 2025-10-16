﻿using XboxCsMgr.XboxLive.Model.TitleStorage;

namespace XboxCsMgr.Client.ViewModels.Controls
{
    public class SavedAtomsViewModel : TreeViewItemViewModel
    {
        private TitleStorageAtomMetadata _atomMetadata;
        private TitleStorageBlobMetadata _atomsblobMetadata;

        private string _atom;
        public string AtomName
        {
            get => _atom;
        }

        private string _atomValue;
        public string AtomValue
        {
            get => _atomValue;
        }
        public TitleStorageAtomMetadata atomMetadata
        {
            get => _atomMetadata;
        }
        public TitleStorageBlobMetadata parentblobMetadata
        {
            get => _atomsblobMetadata;
        }
        public SavedAtomsViewModel(TitleStorageAtomMetadata atomMetadata, string atom, string atomValue, SavedBlobsViewModel parentBlob) : base(parentBlob, true)
        {
            _atomMetadata = atomMetadata;
            _atom = atom;
            _atomValue = atomValue;
            _atomsblobMetadata = parentBlob.BlobMetadata;
        }
    }
}
