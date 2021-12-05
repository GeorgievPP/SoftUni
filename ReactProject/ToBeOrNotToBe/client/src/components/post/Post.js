import React from 'react'
import MoreVertIcon from '@mui/icons-material/MoreVert';

import "./post.css";

export default function Post() {
    return (
        <div className="post">
            <div className="postWrapper">
                <div className="postTop">
                    <div className="postTopLeft">
                        <img className="postProfileImg" src="/assets/person/2.jpg" alt="" />
                        <span className="postUserName">Harry Potter</span>
                        <span className="postDate">5 mins ago</span>
                    </div>
                    <div className="postTopRight">
                        <MoreVertIcon />
                    </div>
                </div>
                <div className="postCenter">
                    <span className="postText">Hey! Its my first post:)</span>
                    <img className="postImg" src="assets/post/1.jpg" alt="" />
                </div>
                <div className="postBottom">
                    <div className="postBottomLeft"></div>
                    <div className="postBottomRight"></div>
                </div>
            </div>
        </div>
    )
}
