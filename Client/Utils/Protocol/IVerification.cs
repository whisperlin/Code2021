using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public interface IVerification
{
    /**
	 * 校验码
	 * @return 字节
	 */
    byte[] verifyCodeByByte(MemoryStream bodyStream, IVerification verification);


}