import { Comment } from "./comment";

export interface Blog {
  id: number;
  title: string;
  content: string;
  comments: Comment[];
}