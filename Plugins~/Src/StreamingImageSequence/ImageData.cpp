#include "stdafx.h"

#include "StreamingImageSequence/ImageData.h"

namespace StreamingImageSequencePlugin {

ImageData::ImageData() 
    : RawData(NULL)
    , Width (0)
    , Height (0)
    , CurrentReadStatus(READ_STATUS_IDLE)
    , Format(IMAGE_FORMAT_RGBA32)
{
}

//----------------------------------------------------------------------------------------------------------------------

ImageData::ImageData(uint8_t* _rawData, uint32_t _width, uint32_t _height, ReadStatus _readStatus) 
    : RawData(_rawData)
    , Width (_width)
    , Height (_height)
    , CurrentReadStatus(_readStatus)
    , Format(IMAGE_FORMAT_RGBA32)
{
}

} //end namespace
