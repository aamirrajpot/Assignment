import React, { useReducer,useEffect, useState } from "react";
import { Button, Icon, TextField, Paper, Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import axios from 'axios';
import { useHistory } from "react-router-dom";
import clsx from 'clsx';
import {  useTheme } from '@material-ui/core/styles';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import ListItemText from '@material-ui/core/ListItemText';
import Select from '@material-ui/core/Select';
import Checkbox from '@material-ui/core/Checkbox';
import Chip from '@material-ui/core/Chip';

// const courses = [
//     'Oliver Hansen',
//     'Van Henry',
//     'April Tucker',
//     'Ralph Hubbard',
//     'Omar Alexander',
//     'Carlos Abbott',
//     'Miriam Wagner',
//     'Bradley Wilkerson',
//     'Virginia Andrews',
//     'Kelly Snyder',
//   ];
  const ITEM_HEIGHT = 48;
  const ITEM_PADDING_TOP = 8;  
  const MenuProps = {
    PaperProps: {
      style: {
        maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
        width: 250,
      },
    },
  };
 
export function MaterialUIFormSubmit(props) {
    const history = useHistory();
  const useStyles = makeStyles(theme => ({
    button: {
      margin: theme.spacing(1)
    },
    leftIcon: {
      marginRight: theme.spacing(1)
    },
    rightIcon: {
      marginLeft: theme.spacing(1)
    },
    iconSmall: {
      fontSize: 20
    },
    root: {
      padding: theme.spacing(3, 2)
    },
    container: {
      display: "flex",
      flexWrap: "wrap"
    },
    textField: {
      marginLeft: theme.spacing(1),
      marginRight: theme.spacing(1),
      width: 400
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
        maxWidth: 300,
      },
      chips: {
        display: 'flex',
        flexWrap: 'wrap',
      },
      chip: {
        margin: 2,
      },
      noLabel: {
        marginTop: theme.spacing(3),
      },
  }));

  const [formInput, setFormInput] = useReducer(
    (state, newState) => ({ ...state, ...newState }),
    {
      name: "",
      rollNo:"",
      email: "",
      phone:"",
      address:"",
      courseIds:[]
    }
  );

  const handleSubmit = evt => {
    evt.preventDefault();
    const headers = {
        'Content-Type': 'application/json'
      }
    const studentObject ={
        name:formInput.name,
        rollNo:formInput.rollNo,
        email:formInput.email,
        phone:formInput.phone,
        address:formInput.address,
        courseIds:personName
    } ;
   console.log(studentObject);
    axios.post('api/Students/Add', studentObject)
    .then(res =>{
        alert("Student added successfully!");
        history.push("/");
      },error=>{
        console.log(error);
      });

  };

  const handleInput = evt => {
    const name = evt.target.name;
    const newValue = evt.target.value;
    setFormInput({ [name]: newValue });
  };
  const [personName, setPersonName] = useState([]);
  const [courses,setCourses] = useState([]);
  const handleChange = (event) => {
    setPersonName(event.target.value);
  };
  const handleChangeMultiple = (event) => {
    const { options } = event.target;
    const value = [];
    for (let i = 0, l = options.length; i < l; i += 1) {
      if (options[i].selected) {
        value.push(options[i].value);
      }
    }
    setPersonName(value);
  };
  useEffect(() => {
    fetchCourses();
  },[]);
  const fetchCourses = () =>{
    const url = window.location.href;
    axios.get('api/Courses/GetAll')
    .then(res =>{
      setCourses(res.data);
    },error=>{
      console.log(error);
    });
  }
  const classes = useStyles();
  return (
    <div>
      <Paper className={classes.root}>
        <Typography variant="h5" component="h3">
          {props.formName}
        </Typography>
        <Typography component="p">{props.formDescription}</Typography>

        <form onSubmit={handleSubmit}>
          <TextField
            label="Name"
            id="margin-normal"
            name="name"
            defaultValue={formInput.name}
            className={classes.textField}
            onChange={handleInput}
          />
            <TextField
            label="Roll No"
            id="margin-normal"
            name="rollNo"
            defaultValue={formInput.rollNo}
            className={classes.textField}
            onChange={handleInput}
          />
          
          <TextField
            label="Email"
            id="margin-normal"
            name="email"
            defaultValue={formInput.email}
            className={classes.textField}
            onChange={handleInput}
          />
           <TextField
            label="Phone No"
            id="margin-normal"
            name="phone"
            defaultValue={formInput.phone}
            className={classes.textField}
            onChange={handleInput}
          />
          <TextField
            label="Address"
            id="margin-normal"
            name="address"
            defaultValue={formInput.address}
            className={classes.textField}
            onChange={handleInput}
          />
          <FormControl className={classes.formControl}>
        <InputLabel id="demo-mutiple-name-label">Select Courses</InputLabel>
        <Select
          labelId="demo-mutiple-name-label"
          id="demo-mutiple-name"
          multiple
          value={personName}
          onChange={handleChange}
          input={<Input />}
          MenuProps={MenuProps}
        >
          {courses.map((course) => (
            <MenuItem key={course.id} value={course.id} >
              {course.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
          <br />
          <Button
            type="submit"
            variant="contained"
            color="primary"
            className={classes.button}
          >
            Add Student
          </Button>
        </form>
      </Paper>
    </div>
  );
}
