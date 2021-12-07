import React, { useEffect, useState } from "react";
//import axios from 'axios'

import "./feed.css";

import Post from "../post/Post";
import Share from "../share/Share";

//import { Posts } from "../../dummyData";

const API_URL = "http://localhost:8800";
export default function Feed({ username }) {
  const [posts, setPost] = useState([]);

  useEffect(() => {
    const fetchPost = async () => {
      const response = username
        ? await fetch(`${API_URL}/api/posts/profile/${username}`)
         : await fetch(`${API_URL}/api/posts/timeline/61af2c68be9cbc27bb9a5a08`);
      const res = await response.json();
      setPost(res);
    };
    fetchPost();
  }, [username]);

  return (
    <div className="feed">
      <div className="feedWrapper">
        <Share />
        {posts.map((p) => (
          <Post key={p._id} post={p} />
        ))}
      </div>
    </div>
  );
}
