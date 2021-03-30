import { Container } from "@material-ui/core";
import React, { Component,useState, useEffect } from 'react';
import { makeStyles,Theme } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { useLocation } from 'react-router-dom';
import axios from 'axios';
import { DataGrid } from '@material-ui/data-grid';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import PropTypes from 'prop-types';
import Button from '@material-ui/core/Button';
import Avatar from '@material-ui/core/Avatar';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemAvatar from '@material-ui/core/ListItemAvatar';
import ListItemText from '@material-ui/core/ListItemText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Dialog from '@material-ui/core/Dialog';
import { NavItem, NavLink } from 'reactstrap';
import Typography from '@material-ui/core/Typography';
import { blue } from '@material-ui/core/colors';
import { Link } from 'react-router-dom';
const useStyles = makeStyles({
  avatar: {
    backgroundColor: blue[100],
    color: blue[600],
  },
});

export function Home(props) {
  const classes = useStyles();
  const { onClose, open } = props;
  const [students, setStudents] = useState([]);
  const handleClose = () => {
    onClose();
  };

  const handleListItemClick = (value) => {
    onClose(value);
  };
  useEffect(() => {
    fetchStudents();
  },[]);
  const fetchStudents = () => {
    debugger
    const url = window.location.href;
    axios.get(url+'api/Students/GetAll')
    .then(res =>{
      setStudents(res.data);
    },error=>{
      console.log(error);
    });
  }
    return(
      <>
      <h3>Students Grid</h3>
    
      <NavLink tag={Link} className="text-dark" to="/add-student">Add Students</NavLink>
     
      <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
          <tr>
            <th>Name</th>
            <th>Roll No</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Address</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {students.map(st =>
            <tr key={st.id}>
              <td>{st.name}</td>
              <td>{st.rollNo}</td>
              <td>{st.email}</td>
              <td>{st.phone}</td>
              <td>{st.address}</td>
              <td> <SimpleDialogDemo Id={st.id} /> </td>
            </tr>
          )}
        </tbody>
      </table>
    </>
    );
  
}
function SimpleDialog(props) {
  const classes = useStyles();
  const { id,onClose, open } = props;
  const [courses,setCourses] = useState([]);

  const fetchCourses = () =>{
    const url = window.location.href;
    axios.get(url+'api/StudentCourses/GetStudentCourses?Id='+id)
    .then(res =>{
      setCourses(res.data);
    },error=>{
      console.log(error);
    });
  }
  const handleClose = () => {
    onClose();
  };
  const handleOpen = () => {
    fetchCourses();
  };
  const handleListItemClick = (value) => {
    onClose();
  };

  return (
    <Dialog onClose={handleClose} onEnter={handleOpen} fullWidth={true} maxWidth="sm" aria-labelledby="simple-dialog-title" open={open}>
      <DialogTitle id="simple-dialog-title">Enrolled Courses</DialogTitle>
      <List>
        {courses.length == 0 ? "Nothing Found" : courses.map((course,index) => (
          <ListItem button onClick={() => handleListItemClick(course.name)} key={course.id}>
            <ListItemAvatar>
              {index+1}
            </ListItemAvatar>
            <ListItemText primary={course.name} />
          </ListItem>
        ))}
      </List>
    </Dialog>
  );
}
SimpleDialog.propTypes = {
  id:PropTypes.number.isRequired,
  onClose: PropTypes.func.isRequired,
  open: PropTypes.bool.isRequired
};
SimpleDialogDemo.propTypes = {
  Id: PropTypes.number.isRequired
};
export default function SimpleDialogDemo(props) {
  const [open, setOpen] = React.useState(false);
  const [selectedValue, setSelectedValue] = React.useState("courses[1]");
  const { Id } = props;
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = (value) => {
    setOpen(false);
    console.log(Id);
    // setSelectedValue(value);
  };

  return (
    <div>
      <Button disableFocusRipple={false} variant="outlined" size="small" color="primary" onClick={handleClickOpen}>
        Show Courses
      </Button>
      <SimpleDialog id={Id} open={open} onClose={handleClose} />
    </div>
  );
}