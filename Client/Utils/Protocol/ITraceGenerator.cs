using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** 
 * 交易
 * @author admin
 */
public interface ITraceGenerator
{

    /** Returns the next trace number. */
     int nextTrace();

    /** Returns the last number that was generated. */
     int getLastTrace();

}
