import React from "react";
import moment from "moment";
import { Link } from 'react-router-dom';

import { Button, Card, Icon, Label, Image } from "semantic-ui-react";

function PostCard({
  post: { body, createdAt, id, username, likeCount, commentCount, likes },
}) {

    function likePost(){
        console.log('Like post');
    }

    function commentOnPost(){
        console.log('Comment post');
    }

  return (
    <Card fluid>
      <Card.Content>
        <Image
          floated="right"
          size="mini"
          src="https://semantic-ui.com/images/avatar2/large/matthew.png"
        />
        <Card.Header>{username}</Card.Header>
        <Card.Meta as={Link} to={`/posts/${id}`}>{moment(createdAt).fromNow(true)}</Card.Meta>
        <Card.Description>{body}</Card.Description>
      </Card.Content>
      <Card.Content extra>
       <Button as='div' labelPosition='right' onClick={likePost}>
           <Button color='teal' basic>
               <Icon name='heart' />
               Like
           </Button>
           <Label basic color="red" pointing='left'>
               {likeCount}
           </Label>
       </Button>
       <Button as='div' labelPosition='right' onClick={commentOnPost}>
           <Button color='blue' basic>
               <Icon name='comments' />
               Comments
           </Button>
           <Label basic color="blue" pointing='left'>
               {commentCount}
           </Label>
       </Button>
      </Card.Content>
    </Card>
  );
}

export default PostCard;
