import React, { useContext, useEffect, useState } from "react";
//import axios from 'axios'

import "./feed.css";

import Post from "../post/Post";
import Share from "../share/Share";
import { AuthContext } from "../../context/AuthContext";

//import { Posts } from "../../dummyData";

const API_URL = "http://localhost:8800";
export default function Feed({ username }) {
  const [posts, setPost] = useState([]);
  const {user} = useContext(AuthContext);

  useEffect(() => {
    const fetchPost = async () => {
      const response = username
        ? await fetch(`${API_URL}/api/posts/profile/${username}`)
         : await fetch(`${API_URL}/api/posts/timeline/${user._id}`);
      const res = await response.json();
      setPost(res.sort((p1, p2) => {
        return new Date(p2.createdAt) - new Date(p1.createdAt);
      }));
    };
    fetchPost();
  }, [username, user._id]);

  return (
    <div className="feed">
      <div className="feedWrapper">
       {(!username || username === user.username) && <Share />}
        {posts.map((p) => (
          <Post key={p._id} post={p} />
        ))}
      </div>
    </div>
  );
}
