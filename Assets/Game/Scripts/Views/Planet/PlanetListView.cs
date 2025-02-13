using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Views
{
    [Serializable]
    public struct PlanetListViewItem
    {
        public string Name;
        public PlanetView PlanetView;
    } 
    
    public class PlanetListView : MonoBehaviour
    {
        [SerializeField] private List<PlanetListViewItem> _planetViews;

        public PlanetView GetPlanetView(string planetName)
        {
            var viewItem = _planetViews.Find(view => view.Name == planetName);
            return viewItem.PlanetView;
        }
    }
}