using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generate
{
    using ScriptableObjectElements;
    using Elements;

    public class GenerateElementLogic : MonoBehaviour
    {
        [SerializeField] private UIMenu _menu;
        [SerializeField] private SpawmPointer _generateArea;
        [SerializeField] private int _countElementToGeneration;

        [SerializeField] private Factory _factory;
        [SerializeField] private TypeElements.TypeElement TypeElement;

        private List<IManipulation> _allObject = new List<IManipulation>();
        private Vector3 _oldSpawnPosition = new Vector3();



        
        private void Start()
        {
            OnLoadGameBoard();
        }

        private void OnLoadGameBoard()
        {
            for(int i = 0; i < _countElementToGeneration;i++)
            {
                Element element = _factory.Get(TypeElement);
                element.transform.position = GeneratePosition(_generateArea);
                element.transform.SetParent(_generateArea.transform);

                _allObject.Add(element);
            }

            _menu.Initialize(_allObject);
        }

        private Vector3 GeneratePosition(SpawmPointer spawmPointer)
        {
           if(spawmPointer is null) throw new System.NullReferenceException("Spawn Pointer is null");

           Vector3 spawnerBoundsMin = spawmPointer.BoundsMin;
           Vector3 spawnerBoundsMax = spawmPointer.BoundsMax;

           float randX = Random.Range(spawnerBoundsMin.x,spawnerBoundsMax.x);
           float randZ = Random.Range(spawnerBoundsMin.z,spawnerBoundsMax.z);

           Vector3 newSpawnPosition = new Vector3(randX,1f,randZ);

            if(Vector3.Distance(newSpawnPosition,_oldSpawnPosition) < 2)
                return GeneratePosition(spawmPointer);

            
            _oldSpawnPosition = newSpawnPosition;

            return newSpawnPosition;
        }

    }

}
