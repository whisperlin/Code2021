using System.Collections.Generic;
using System.IO;
namespace com.hbt.protocol.po.chapter{

/// <summary>
 /// 关卡进度情况
 /// </summary>
public class ChapterInfoPo_Rp  : BasePo{

	public const int cmd = -770900;
	public const string reflectClassName = "com.hbt.protocol.po.chapter.ChapterInfoPo_Rp";

	public ChapterInfoPo_Rp():base() {
		commandId = -770900;
		encryptTypeDown = 0;
	}

	public ChapterInfoPo_Rp(MemoryStream inputStream){
		commandId = -770900;
		encryptTypeDown = 0;
		this.setPlayingId(PackageUtil.DecodeInteger(inputStream));
		this.setLastResult(PackageUtil.DecodeInteger(inputStream));

		short length0 = PackageUtil.DecodeShort(inputStream);//集合长度
		List<com.hbt.protocol.po.chapter.ChapterProgressPo> progress = new List<com.hbt.protocol.po.chapter.ChapterProgressPo>();
		for(int i = 0; i < length0; i++){
			PackageUtil.skipInputStream(inputStream, 4);//读4位
			progress.Add(new com.hbt.protocol.po.chapter.ChapterProgressPo(inputStream));
		}
		this.setProgress(progress);
	}

	public override void encodeVo(MemoryStream outputStream){
		PackageUtil.EncodeInteger(outputStream, commandId);
		PackageUtil.EncodeInteger(outputStream, getPlayingId());
		PackageUtil.EncodeInteger(outputStream, getLastResult());

		List<com.hbt.protocol.po.chapter.ChapterProgressPo> progress = getProgress();
		short progresslength = (short)(progress == null ? 0 : progress.Count);
		PackageUtil.EncodeShort(outputStream, progresslength);
		for(int i = 0; i < progresslength; i++){
			progress[i].encodeVo(outputStream);
		}
	}

	/// <summary>
	 ///正在进行游戏的关卡ID,-1,0则没有进行中的游戏
	 /// </summary>
	private int playingId; 

	/// <summary>
	 ///上一次游戏状态:ChapterConst.STATUS_*
	 /// </summary>
	private int lastResult; 

	/// <summary>
	 ///关卡进度情况
	 /// </summary>
	private List<com.hbt.protocol.po.chapter.ChapterProgressPo> progress; 

	/// <summary>
	 ///正在进行游戏的关卡ID,-1,0则没有进行中的游戏
	 /// </summary>
	public void setPlayingId(int playingId){
		this.playingId=playingId;
	}

	/// <summary>
	 ///正在进行游戏的关卡ID,-1,0则没有进行中的游戏
	 /// </summary>
	public int  getPlayingId(){  
		return playingId; 
	}

	/// <summary>
	 ///上一次游戏状态:ChapterConst.STATUS_*
	 /// </summary>
	public void setLastResult(int lastResult){
		this.lastResult=lastResult;
	}

	/// <summary>
	 ///上一次游戏状态:ChapterConst.STATUS_*
	 /// </summary>
	public int  getLastResult(){  
		return lastResult; 
	}

	/// <summary>
	 ///关卡进度情况
	 /// </summary>
	public void setProgress(List<com.hbt.protocol.po.chapter.ChapterProgressPo> progress){
		this.progress=progress;
	}

	/// <summary>
	 ///关卡进度情况
	 /// </summary>
	public List<com.hbt.protocol.po.chapter.ChapterProgressPo> getProgress(){  
		return progress; 
	}

	public override string ToString() {
		return "playingId:" + playingId + "," + "lastResult:" + lastResult + "," + "progress size:" + progress.Count;
	}

}
}