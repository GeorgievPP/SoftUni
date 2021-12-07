import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { format } from "timeago.js"

import MoreVertIcon from "@mui/icons-material/MoreVert";

import "./post.css";

//import { Users } from "../../dummyData";
const API_URL = 'http://localhost:8800';

export default function Post({ post }) {
  const [like, setLike] = useState(post.likes.length);
  const [isLiked, setIsLiked] = useState(false);
  const [user, setUser] = useState({});
  const PF = "http://localhost:3000/assets/";

  useEffect(() => {
    const fetchUser = async () => {
        const response = await fetch(`${API_URL}/api/users?userId=${post.userId}`);
        const res = await response.json();
        setUser(res);
    };
    fetchUser();
  }, [post.userId]);


  const likeHandler = () => {
    setLike(isLiked ? like - 1 : like + 1);
    setIsLiked(!isLiked);
  };

  return (
    <div className="post">
      <div className="postWrapper">
        <div className="postTop">
          <div className="postTopLeft">
            <Link to={`profile/${user.username}`}>
            <img
              className="postProfileImg"
              src={user.profilePicture || PF+"person/noAvatar.png"}
              alt=""
            />
            </Link>
            <span className="postUserName">
              {user.username}
            </span>
            <span className="postDate">{format(post.createdAt)}</span>
          </div>
          <div className="postTopRight">
            <MoreVertIcon />
          </div>
        </div>
        <div className="postCenter">
          <span className="postText">{post?.desc}</span>
          <img className="postImg" src={PF + post.img} alt="" />
        </div>
        <div className="postBottom">
          <div className="postBottomLeft">
            <img
              className="likeIcon"
              src={`${PF}like.png`}
              onClick={likeHandler}
              alt=""
            />
            <img
              className="likeIcon"
              src={`${PF}heart.png`}
              onClick={likeHandler}
              alt=""
            />
            <span className="postLikeCounter">{like} people like it</span>
          </div>
          <div className="postBottomRight">
            <span className="postCommentText">{post.comment} comments</span>
          </div>
        </div>
      </div>
    </div>
  );
}
