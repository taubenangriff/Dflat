# GIS Structures 

GIS Structures as defined in David Lewin's _Generalized Musical Intervals and Transformations_ will be the backbone of the library as those allow us to switch between different ways of thinking through Congruence between interval groups. In easy terms, that means that we can do calculations on an already implemented GIS and then map the result back.

At the moment this library is just a small implementation of GIS Structures and methods of creating them. The next step is creating a versatile and understandable music theory layer which's functionality can compute on GIS structures.  

# Ideas of GIS implementation: 

- Notes in functional theory as a tuple of (Pitch, Accidental) computes on `GIS<Complex>` 
- Notes in 12-tone temperament computes on `GIS<Integer>`
- Frequencies compute on `GIS<float>` or `GIS<Integer>`

# Music Theory Layer

A good reference might be [tonal.js](https://github.com/tonaljs/tonal/tree/main):

## Note System 

- name 
- pitch class 
- letter 
- accidentals
- alteration 
- octave

## Scale System : Exlusively Pitch Classes?  

- Scale Types: Defined as Intervals
- Scales: Instances of Scale Types.
- Extensible: User should be able to add new Scale Types to exhaust the current scale obsessions.
- Scale Detection

## Rhythm

# Extension Methods

## Midi 
    using Midi Specification as Congruence
    - Note <> Midi Note 
    - Duration <> Midi Duration

## Frequencies 
    using Tuning Systems as Congruence  (More like: Tuning System is a Congruence that shall explicitly be named as such)
    - Note <> Frequency 
