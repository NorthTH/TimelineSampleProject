using UnityEngine;
using UnityEngine.Timeline;
using DG.Tweening;

/// <summary>
/// TimeLineを使った演出用基底クラス。
/// </summary>
public class BaseTimeControl : MonoBehaviour, ITimeControl
{
    public Sequence m_Sequence = null;
	
    /// <summary>
    /// クリップ侵入時に呼ばれる
    /// </summary>
	public void OnControlTimeStart ()
	{
        OnStart();
	}

    /// <summary>
    /// クリップ退出時
    /// </summary>
	public void OnControlTimeStop ()
	{
        OnEnd();
	}

    /// <summary>
    /// 変更通知が来た際に、呼ばれます。
    /// Script更新時にも呼ばれます。
    /// </summary>
    void OnValidate()
    {
        SetupAction();
    }

    /// <summary>
    /// 何度も呼ばれる
    /// </summary>
	public void SetTime (double _time)
	{
        if(m_Sequence == null)
        {
            return;
        }
        m_Sequence.Goto((float)_time);
	}

    /// <summary>
    /// シーケンスの初期化。
    /// </summary>
    protected void InitSequence()
    {
        if(m_Sequence != null)
        {
            m_Sequence.Goto(0);
            m_Sequence.Kill();
        }
        m_Sequence = DOTween.Sequence();
    }

    /// <summary>
    /// 動作を記述してください。
    /// </summary>
    protected virtual void SetupAction()
    {
    }

    protected virtual void OnStart()
    {
    }

    protected virtual void OnEnd()
    {
    }
}