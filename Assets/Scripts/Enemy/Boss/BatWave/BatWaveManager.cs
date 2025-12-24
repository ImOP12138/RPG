using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWaveManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    

    public BatWave[] waves;
    private BatWave _currentWave;
    private int _currentWaveIndex;
    
    private void Start()
    {
        if(spawnPoints.Length==0)
        {
            return;
        }
        StartCoroutine(NextWaveCoroutine());
    }
    private IEnumerator NextWaveCoroutine()
    {
        _currentWaveIndex++;
        if(_currentWaveIndex-1<waves.Length)
        {
            _currentWave = waves[_currentWaveIndex-1];
            
            for(int i=0;i<_currentWave.count;i++)
            {
                int spawnIndex=Random.Range(0,spawnPoints.Length);
                
                SmartBat bat=Instantiate(_currentWave.bat,spawnPoints[spawnIndex].position,Quaternion.identity);
                
                yield return new WaitForSeconds(_currentWave.timeBetweenSpawn);
            }
        }
    }
    //教程（BV号：BV1a84y1j7yC）还有可以切换不同敌人类型的部分这里暂时没有多余的怪物就没继续扩展功能了

}
